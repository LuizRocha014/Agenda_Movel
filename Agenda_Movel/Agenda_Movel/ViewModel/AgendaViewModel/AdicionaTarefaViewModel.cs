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

        private string _titulo;
        private string _observacao;
        private DateTime _dataInical;
        private TimeSpan _horarioEvento;

        public Command AdicionaAgendaCommand => _adicionaAgenda ?? (_adicionaAgenda = new Command(async () => AdicionaAgenda()));

        public string Titulo { get { return _titulo; } set { _titulo = value; OnPropertyChanged("Titulo"); } }
        public string Observacao { get { return _observacao; } set { _observacao = value; OnPropertyChanged("Observacao"); } }
        public TimeSpan HorarioEvento { get { return _horarioEvento; } set { _horarioEvento = value; OnPropertyChanged("HorarioEvento"); } }
        public DateTime DataEvento { get { return _dataInical; } set { _dataInical = value; OnPropertyChanged("DataEvento"); } }


        public AdicionaTarefaViewModel()
        {
            _agendaRepository = new AgendaRepository();
            _horarioEvento = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
            _dataInical = DateTime.Now;
        }
        public void AdicionaAgenda()
        {
            _agendaRepository.InsertOrReplace(new Agenda()
            {

                Inclusao = DateTime.Now,
                Titulo = _titulo,
                Obaservacao = _observacao,
                DataInicial = _dataInical,
                DataFinal = _horarioEvento


            });

            App.Current.MainPage.Navigation.PopAsync();

        }

    }
}
