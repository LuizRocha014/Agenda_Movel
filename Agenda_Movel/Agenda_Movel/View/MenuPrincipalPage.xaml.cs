using Agenda_Movel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda_Movel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipalPage : ContentPage
    {
        private MenuPrincipalViewModel _menuPrincipalViewModel;
        public MenuPrincipalPage()
        {
            InitializeComponent();
            _menuPrincipalViewModel  = BindingContext as MenuPrincipalViewModel;


        }
        void hamburgerButton_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

      

        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            _menuPrincipalViewModel.MudaPaginaAsync(e.ItemData);
        }
    }
}