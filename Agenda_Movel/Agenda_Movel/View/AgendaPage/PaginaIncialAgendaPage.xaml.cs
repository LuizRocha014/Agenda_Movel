﻿using Agenda_Movel.ViewModel.AgendaViewModel;
using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Agenda_Movel.View.Agenda
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaIncialAgendaPage : ContentPage
	{
		private PaginaIncialAgendaViewModel _paginaIncialAgendaViewModel;
        private DateTime _dataAddAgenda;
        private DateTime _monthSelected;
        public PaginaIncialAgendaPage ()
		{
			InitializeComponent ();
            _paginaIncialAgendaViewModel = new PaginaIncialAgendaViewModel ();
            BindingContext = _paginaIncialAgendaViewModel;
            Appointments();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            On<iOS>().SetUseSafeArea(true);
            Appointments();
            try
            {

            }
            catch (Exception)
            {
              
            }
            finally
            {
               
            }
        }
        public void Appointments()
        {
            try
            {
                //Cria uma instância para ScheduleAppointmentCollection
               var list  = _paginaIncialAgendaViewModel.IniciaListAgenda();
                //Para que  a lista que retornou do WS seja reconhecida como Appointment.
                ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();
                //_agendaPartialViewModel.ListarAgenda();
                var ScheduleAppointments = list.Select(ag => new ScheduleAppointment
                {
                    Id = ag.Id,
                    StartTime = ag.DataInicial,
                    EndTime = ag.DataFinal,
                    //Formatado na model a separação!
                    Subject = ag.Titulo,
                    Location = "Gama STI",
                    Color = Color.FromHex(ag.CorStatus),
                    Notes = ag.Obaservacao,

                }).ToList();

                foreach (var scheduleAppointment in ScheduleAppointments)
                {
                    scheduleAppointmentCollection.Add(scheduleAppointment);
                }

                schedule.EnableNavigation = true;
                //Troca o idioma do componente para Português
                schedule.Locale = "PT";
                //Seta a collection criada como DataSource (não é necessário nenhum binding pra isso)
                schedule.DataSource = scheduleAppointmentCollection;

                //schedule.ScheduleHeaderDateFormat = DateTime.Today.ToString();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }
        private void schedule_CellTapped(object sender, Syncfusion.SfSchedule.XForms.CellTappedEventArgs e)
        {
            _dataAddAgenda = e.Datetime;
        }

        private void schedule_CellDoubleTapped(object sender, Syncfusion.SfSchedule.XForms.CellTappedEventArgs e)
        {
            var data = e.Datetime;
        
            App.Current.MainPage.Navigation.PushAsync(new AdicionaTarefaPage(data),false);
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            
           App.Current.MainPage.Navigation.PushAsync(new AdicionaTarefaPage(_dataAddAgenda), false);
        }

        
    }
}