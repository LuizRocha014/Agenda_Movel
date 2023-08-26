using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Models.Cummons;
using Agenda_Movel.Data.Repository;
using Agenda_Movel.Data.Service;
using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Agenda_Movel.ViewModel.AgendaViewModel
{
    class PaginaIncialAgendaViewModel : BaseViewModel
    {

        private ObservableCollection<Agenda> _listaAgenda;
        private IAgendasRepository _agendaRepository;

        public ObservableCollection<Agenda> ListaAgendas { get { return _listaAgenda; } set { _listaAgenda = value; OnPropertyChanged("ListaAgendas"); } }

        public PaginaIncialAgendaViewModel()
        {
            _agendaRepository = new AgendaRepository();
            _listaAgenda = new ObservableCollection<Agenda>();
             //IniciaListAgenda();
          

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
    }
}
