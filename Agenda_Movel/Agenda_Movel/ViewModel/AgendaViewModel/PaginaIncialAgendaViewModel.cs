using Acr.UserDialogs;
using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Models.Cummons;
using Agenda_Movel.Data.Repository;
using Agenda_Movel.Data.Service;
using Agenda_Movel.View.Agenda;
using Agenda_Movel.View.ClienteView;
using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agenda_Movel.ViewModel.AgendaViewModel
{
    class PaginaIncialAgendaViewModel : BaseViewModel
    {

        private ObservableCollection<Agenda> _listaAgenda;
        private ObservableCollection<Agenda> _listaAgendaHome;
        private ObservableCollection<Cliente> _listaCliente;
        private IList<ToolbarItem> _toolbarItem;

        private IAgendasRepository _agendaRepository;
        private IClienteReprository _clienteReprository;

        private DateTime _dataAddAgenda;

        Command _AdicionaAgenda;
        Command _carregaListaAgenda;
        Command _adicionaClienteCommand;

        private string _tituloPage;

        public ObservableCollection<Agenda> ListaAgendas { get { return _listaAgenda; } set { _listaAgenda = value; OnPropertyChanged("ListaAgendas"); } } 
        public ObservableCollection<Agenda> ListaAgendaHome { get { return _listaAgendaHome; } set { _listaAgendaHome = value; OnPropertyChanged("ListaAgendaHome"); } }
        public ObservableCollection<Cliente> ListaCliente { get { return _listaCliente; } set { _listaCliente = value; OnPropertyChanged("ListaCliente"); } }
        public string Titulo { get { return _tituloPage; } set { _tituloPage = value; OnPropertyChanged("Titulo"); } }
        public IList<ToolbarItem> ToolbarItem { get { return _toolbarItem; } set { _toolbarItem = value; OnPropertyChanged("ToolbarItem"); } }
        public DateTime DataAddAgenda { get { return _dataAddAgenda; } set { _dataAddAgenda = value; OnPropertyChanged("DataAddAgenda"); } }

        public Command AdiconaAgenda => _AdicionaAgenda ?? (_AdicionaAgenda = new Command(async () => { AdicionaAgenda(DataAddAgenda); }));
        public Command AdicionaClienteCommand => _adicionaClienteCommand ?? (_adicionaClienteCommand = new Command(async () => {await App.Current.MainPage.Navigation.PushAsync(new AdiconarClientePage(), false); }));
        public Command CarregaListaAgendaCommand => _carregaListaAgenda ?? (_carregaListaAgenda = new Command(async () => { CarregaLista(); }));


        public PaginaIncialAgendaViewModel()
        {
            _agendaRepository = new AgendaRepository();
            _listaAgenda = new ObservableCollection<Agenda>();
            _clienteReprository = new ClienteRepository();
            DataAddAgenda = DateTime.Now;

        }

        public List<Agenda> CarretaListaAgenda()
        {
            try
            {
                return _agendaRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CarregaLista()
        {
            try
            {
                using (var loding = UserDialogs.Instance.Loading("Carregando...",null,null,true, MaskType.Black))
                {
                    ListaAgendas = new ObservableCollection<Agenda>(_agendaRepository.GetAll());
                    ListaCliente = new ObservableCollection<Cliente>(_clienteReprository.GetCLientesOrder());
                    ListaAgendaHome = new ObservableCollection<Agenda>(_agendaRepository.GetAll().OrderByDescending(x => x.DataInicial));
                }  
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AdicionaAgenda(DateTime data)
        {
            App.Current.MainPage.Navigation.PushAsync(new AdicionaTarefaPage(data), false);
        }
        public async Task TrocaTabView(int index)
        {
            switch (index)
            {
                case 0:
                    _tituloPage = "Home";
                    CarregaLista();
                    _toolbarItem.Clear();
                    ToolbarItem.Add(new ToolbarItem { Text = "Recarregar", ClassId = "Recarregar", Command = CarregaListaAgendaCommand, Order = ToolbarItemOrder.Secondary });
                    OnPropertyChanged("Titulo");
                    break; 
                case 1:
                    _tituloPage = "Agenda";
                    ToolbarItem.Clear();
                    ToolbarItem.Add(new ToolbarItem { Text = "Adicionar", ClassId = "Adicionar", Command = AdiconaAgenda, Order = ToolbarItemOrder.Primary });
                    OnPropertyChanged("Titulo");
                    break;
                case 2:
                    _tituloPage = "Cliente";
                    CarregaLista();
                    ToolbarItem.Clear();
                    ToolbarItem.Add(new ToolbarItem { Text = "Adicionar", ClassId = "Adicionar", Command = AdicionaClienteCommand, Order = ToolbarItemOrder.Primary });
                    ToolbarItem.Add(new ToolbarItem { Text = "Recarregar", ClassId = "Recarregar", Order = ToolbarItemOrder.Secondary });
                    OnPropertyChanged("Titulo");
                    OnPropertyChanged("ListaCliente");
                    break;
                default:
                    break;
            }
        }
    }
}
