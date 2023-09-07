using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Models.Cummons;
using Agenda_Movel.Data.Repository;
using Agenda_Movel.Data.Service;
using Agenda_Movel.View.Agenda;
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
        private IAgendasRepository _agendaRepository;
        private IList<ToolbarItem> _toolbarItem;
        private DateTime _dataAddAgenda;

        Command _AdicionaAgenda;
        Command _carregaListaAgenda;

        private string _tituloPage;

        public ObservableCollection<Agenda> ListaAgendas { get { return _listaAgenda; } set { _listaAgenda = value; OnPropertyChanged("ListaAgendas"); } } 
        public ObservableCollection<Agenda> ListaAgendaHome { get { return _listaAgendaHome; } set { _listaAgendaHome = value; OnPropertyChanged("ListaAgendaHome"); } }
        public string Titulo { get { return _tituloPage; } set { _tituloPage = value; OnPropertyChanged("Titulo"); } }
        public IList<ToolbarItem> ToolbarItem { get { return _toolbarItem; } set { _toolbarItem = value; OnPropertyChanged("ToolbarItem"); } }
        public DateTime DataAddAgenda { get { return _dataAddAgenda; } set { _dataAddAgenda = value; OnPropertyChanged("DataAddAgenda"); } }

        public Command AdiconaAgenda => _AdicionaAgenda ?? (_AdicionaAgenda = new Command(async () => { AdicionaAgenda(DataAddAgenda); }));
        public Command CarregaListaAgendaCommand => _carregaListaAgenda ?? (_carregaListaAgenda = new Command(async () => { CarregaListaAgenda(); }));


        public PaginaIncialAgendaViewModel()
        {
            _agendaRepository = new AgendaRepository();
            _listaAgenda = new ObservableCollection<Agenda>();
            DataAddAgenda = DateTime.Now;

        }

        public  List<Agenda>  IniciaListAgenda()
        {
            try
            {
                _agendaRepository = new AgendaRepository();
                return _agendaRepository.GetAll();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async void CarregaListaAgenda() 
        {

            ListaAgendaHome =  new ObservableCollection<Agenda>(_agendaRepository.GetAll().OrderByDescending(x=>x.DataInicial));
            
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
                    CarregaListaAgenda();
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
                    ToolbarItem.Clear();
                    ToolbarItem.Add(new ToolbarItem { Text = "Adicionar", ClassId = "Adicionar", Command = AdiconaAgenda, Order = ToolbarItemOrder.Primary });
                    ToolbarItem.Add(new ToolbarItem { Text = "Recarregar", ClassId = "Recarregar", Order = ToolbarItemOrder.Secondary });
                    OnPropertyChanged("Titulo");
                    break;
                default:
                    break;
            }
        }
    }
}
