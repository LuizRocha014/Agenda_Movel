using Agenda_Movel.Data.Models;
using Agenda_Movel.View.viewPopup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agenda_Movel.ViewModel
{
    public class MenuPrincipalViewModel : BaseViewModel
    {

        private List<MenuInicial> _listaMenuInicial;

        public List<MenuInicial> ListMenuInicial { get { return _listaMenuInicial; } set { _listaMenuInicial = value; OnPropertyChanged("ListaMenuInicial"); } }


        public MenuPrincipalViewModel()
        {
            _listaMenuInicial = new List<MenuInicial>();
            _listaMenuInicial.Add(new MenuInicial { Nome = "Agenda", Valor = "GetAgenda" });
            _listaMenuInicial.Add(new MenuInicial { Nome = "Oficina", Valor = "GetOficina" });
            OnPropertyChanged("ListMenuInicial");
        }

        public async void MudaPaginaAsync(object valor)
        {
            Console.WriteLine(valor);
            switch (valor)
            {
                case 0:
                    await PopupNavigation.PushAsync(new SelecaoPopupPage());
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
                default:
                    break;
            }
        }

    }

}
