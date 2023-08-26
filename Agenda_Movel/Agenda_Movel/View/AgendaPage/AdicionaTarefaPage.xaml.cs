using Agenda_Movel.ViewModel.AgendaViewModel;
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

    public partial class AdicionaTarefaPage : ContentPage
    {
        private AdicionaTarefaViewModel _adicionaTarefaViewModel;
        public AdicionaTarefaPage(DateTime? dataSelecionada)
        {
            InitializeComponent();
            _adicionaTarefaViewModel = BindingContext as AdicionaTarefaViewModel;
            _adicionaTarefaViewModel.DataEvento = dataSelecionada ?? DateTime.Now;
        }

      
    }
}