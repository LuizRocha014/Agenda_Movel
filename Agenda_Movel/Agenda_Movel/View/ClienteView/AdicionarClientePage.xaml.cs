using Agenda_Movel.Data.Models;
using Agenda_Movel.ViewModel.ClienteViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda_Movel.View.ClienteView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdiconarClientePage : ContentPage
    {
        private AdiconarClienteViewModel _adiconarClienteViewModel;
        public AdiconarClientePage()
        {
            InitializeComponent();
            _adiconarClienteViewModel = BindingContext as AdiconarClienteViewModel;
            _adiconarClienteViewModel.CarregaDados();
            _adiconarClienteViewModel.Navigation = this.Navigation;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (e.NewTextValue.Count() != 11)
                {
                    throw new ArgumentException("O número de telefone deve conter 12 dígitos (DDD + número).");
                }

                string ddd = e.NewTextValue.Substring(2, 2);
                string numero = e.NewTextValue.Substring(4, 8);

                Console.WriteLine($"({ddd}) {numero.Substring(0, 4)}-{numero.Substring(4)}");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void VaidaCampos()
        {
            try
            {
                if (string.IsNullOrEmpty(NomeEditor.Text)) throw new Exception("Preencha o Nome.");
                if (string.IsNullOrEmpty(SobrenomeEditor.Text)) throw new Exception("Preencha o Sobrenome");
                if (maskedEdit.Value == null) throw new Exception("Preencha o Telefone Principal.");
                if (maskedEdit3.Value == null) throw new Exception("Preencha o CEP");

            }
            catch (Exception e)
            {

                App.Current.MainPage.DisplayAlert("Atenção", e.Message, "OK");
            }
        }
        public void SfButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                VaidaCampos();
                var cliente = new Cliente()
                {
                    TelefonePrimario = _adiconarClienteViewModel.TelefonePrimario = maskedEdit.Value.ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim(),
                    Nome = NomeEditor.Text,
                    Sobrenome = SobrenomeEditor.Text,
                    Cep = maskedEdit3.Value.ToString().Replace("-", "")

                };
                _adiconarClienteViewModel.AdicionaCliente(cliente);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }

        private void maskedEdit3_ValueChanged(object sender, Syncfusion.XForms.MaskedEdit.ValueChangedEventArgs e)
        {
            var cep = e.Value.ToString().Replace("-", "");

            if (cep.Count() == 8)
            {
                _adiconarClienteViewModel.BuscaCep(cep);
            }
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            _adiconarClienteViewModel.NumeroCasa = e.NewTextValue;
            Console.WriteLine(e.NewTextValue);
        }
    }
}