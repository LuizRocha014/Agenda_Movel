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

        private ObservableCollection<Agenda> _listaAgenda;

        public ObservableCollection<Agenda> ListaAgendas { get { return _listaAgenda; } set { _listaAgenda = value; OnPropertyChanged("ListaAgendas"); } }

        public PaginaIncialAgendaViewModel()
        {
            _listaAgenda = new ObservableCollection<Agenda>();
             IniciaListAgenda();
          

        }

        public async void IniciaListAgenda()
        {
            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda", DataInicial = DateTime.Now, DataFinal = DateTime.Now , Status = Agenda.StatusAgenda.Agendado});
            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda2", DataInicial = DateTime.Now, DataFinal = DateTime.Now, Status = Agenda.StatusAgenda.Finalizado });
            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda3", DataInicial = DateTime.Now, DataFinal = DateTime.Now, Status = Agenda.StatusAgenda.Remarcado });
            _listaAgenda.Add(new Agenda() { Titulo = "Teste Agenda4", DataInicial = DateTime.Now, DataFinal = DateTime.Now, Status = Agenda.StatusAgenda.Cancelado });

        }
    }
}
