using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Repository;
using Agenda_Movel.Data.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Agenda_Movel.ViewModel.AgendaViewModel
{
    class AdicionaTarefaViewModel : BaseViewModel
    {

        private IAgendasRepository _agendaRepository;
        private Command _adicionaAgenda;
        private IList<ToolbarItem> _toolbarItem;

        private string _titulo;
        private string _observacao;
        private bool _edicao;
        private DateTime _dataInical;
        private TimeSpan _horarioEvento;

        public Command AdicionaAgendaCommand => _adicionaAgenda ?? (_adicionaAgenda = new Command(async () => AdicionaAgenda()));

        public string Titulo { get { return _titulo; } set { _titulo = value; OnPropertyChanged("Titulo"); } }
        public string Observacao { get { return _observacao; } set { _observacao = value; OnPropertyChanged("Observacao"); } }
        public bool Edicao { get { return _edicao; } set { _edicao = value; OnPropertyChanged("Edicao"); } }
        public TimeSpan HorarioEvento { get { return _horarioEvento; } set { _horarioEvento = value; OnPropertyChanged("HorarioEvento"); } }
        public DateTime DataEvento { get { return _dataInical; } set { _dataInical = value; OnPropertyChanged("DataEvento"); } }
        public IList<ToolbarItem> ToolbarItem { get { return _toolbarItem; } set { _toolbarItem = value; OnPropertyChanged("ToolbarItem"); } }


        public AdicionaTarefaViewModel()
        {
            _agendaRepository = new AgendaRepository();
            _horarioEvento = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
            _dataInical = DateTime.Now;
        }

        public void CarregaToolbar()
        {
            ToolbarItem.Clear();
            if(_edicao)
            {
                ToolbarItem.Add(new ToolbarItem { Text = "Editar", ClassId = "Editar", Order = ToolbarItemOrder.Primary });
                ToolbarItem.Add(new ToolbarItem { Text = "Cencelar", ClassId = "Cancelar", Order = ToolbarItemOrder.Secondary });
            }           
        }
        public void AdicionaAgenda()
        {
            _dataInical += _horarioEvento;
            var dataFinal = _dataInical.AddMinutes(20);
            _agendaRepository.InsertOrReplace(new Agenda()
            {

                Inclusao = DateTime.Now,
                Titulo = _titulo,
                Obaservacao = _observacao,
                DataInicial = _dataInical,
                DataFinal = dataFinal


            });

            App.Current.MainPage.Navigation.PopAsync();

        }

        

    }
}
