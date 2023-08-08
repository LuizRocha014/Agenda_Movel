using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Models.Cummons;
using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Agenda_Movel.ViewModel.AgendaViewModel
{
    class PaginaIncialAgendaViewModel : BaseViewModel
    {

        private ScheduleAppointmentCollection _calendarInlineEvents;
        private ObservableCollection<Agenda> _listaAgenda;

        public ScheduleAppointmentCollection ListScheduleAppointment { get { return _calendarInlineEvents; } set { _calendarInlineEvents = value; OnPropertyChanged("ListScheduleAppointment"); } }
        public ObservableCollection<Agenda> ListaAgendas { get { return _listaAgenda; } set { _listaAgenda = value; OnPropertyChanged("ListaAgendas"); } }

        public PaginaIncialAgendaViewModel()
        {
            _listaAgenda = new ObservableCollection<Agenda>();

            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda", DataInicial = DateTime.Now, DataFinal = DateTime.Now });
            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda2", DataInicial = DateTime.Now, DataFinal = DateTime.Now });
            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda3", DataInicial = DateTime.Now, DataFinal = DateTime.Now });
            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda4", DataInicial = DateTime.Now, DataFinal = DateTime.Now });

            var ScheduleAppointments = _listaAgenda.Select(x => new ScheduleAppointment
            {
                Id = x.Id,
                StartTime = x.DataInicial,
                EndTime = x.DataFinal,
                Notes = x.Obaservacao,
                Subject = x.Titulo
            }).ToList();

            foreach (var scheduleAppointment in ScheduleAppointments)
            {
                
                ListScheduleAppointment.Add(scheduleAppointment);
            }



        }
    }
}
