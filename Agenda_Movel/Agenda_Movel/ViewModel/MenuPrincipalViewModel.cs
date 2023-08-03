using Agenda_Movel.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        public void MudaPagina(object valor)
        {
            switch (valor)
            {
                case "GetAgenda":
                    break;
                case "GetOficina":
                    break;
                default:
                    break;
            }
        }   

    }

}
