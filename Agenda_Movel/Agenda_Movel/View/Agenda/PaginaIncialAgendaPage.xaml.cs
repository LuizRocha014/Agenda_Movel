using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda_Movel.View.Agenda
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaIncialAgendaPage : ContentPage
	{
		public PaginaIncialAgendaPage ()
		{
			InitializeComponent ();
		}

        private void calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {

        }
    }
}