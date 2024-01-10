using Acr.UserDialogs;
using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Repository;
using Agenda_Movel.Data.Service;
using Agenda_Movel.View.ClienteView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agenda_Movel.ViewModel.ClienteViewModel
{
    class AdiconarClienteViewModel : BaseViewModel
    {

        private INavigation _navigation;
        private IClienteReprository _clienteReprository;
        private Command _AvancaClienteEndereco;

        private Endereco _endereco;

        private string _cep;
        private string _telefonePrimario;
        private string _telefoneSecundario;
        private string _nome;
        private string _sobrenome;
        private string _numeroCasa;
        private string _Rua;
        private string _cidade;
        private bool _isEndereco = false;

        public INavigation Navigation { get { return _navigation; } set { value = _navigation; } }
        public Endereco Endereco { get { return _endereco; } set { value = _endereco; OnPropertyChanged("Endereco"); } }
        public string CEP { get { return _cep; } set { value = _cep; } }
        public string Nome { get { return _cep; } set { value = _cep; OnPropertyChanged("Nome"); } }
        public string Sobrenome { get { return _nome; } set { value = _nome; OnPropertyChanged("Sobrenome"); } }
        public string TelefonePrimario { get { return _telefonePrimario; } set { value = _telefonePrimario; OnPropertyChanged("TelefonePrimario"); } }
        public string TelefoneSecundario { get { return _telefoneSecundario; } set { value = _telefoneSecundario; OnPropertyChanged("TelefoneSecundario"); } }
        public string NumeroCasa { get { return _numeroCasa; } set { value = _numeroCasa; OnPropertyChanged("NumeroCasa"); } }
        public string Rua { get { return _Rua; } set { value = _Rua; OnPropertyChanged("Rua"); } }
        public string Cidade { get { return _cidade; } set { value = _cidade; OnPropertyChanged("Cidade"); } }
        public bool IsEndereco { get { return _isEndereco; } set { value = _isEndereco; OnPropertyChanged("IsEndereco"); } }

        public Command AvancaClienteEndereco => _AvancaClienteEndereco ?? (_AvancaClienteEndereco = new Command(async () =>
        {
            // var endereco = await BuscaCep(CEP);
            await Navigation.PushAsync(new AdicionaClienteEderecoPage(), false);
        }));

        public async void CarregaDados()
        {
            _clienteReprository = new ClienteRepository();
        }


        public async Task BuscaCep(string cep)
        {
            try
            {
                using (var loding = UserDialogs.Instance.Loading("Carregando...", null, null, true, MaskType.Black))
                {

                    string url = $"https://viacep.com.br/ws/{cep}/json/";
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetStringAsync(url);
                        _endereco = JsonConvert.DeserializeObject<Endereco>(response);
                        _Rua = _endereco.logradouro;
                        _cidade = _endereco.localidade;
                        _isEndereco = true;
                        OnPropertyChanged("Rua");
                        OnPropertyChanged("Cidade");
                        OnPropertyChanged("IsEndereco");
                        Console.WriteLine(_cidade);
                    }
                }
            }
            catch (Exception w)
            {

                throw w;
            }
        }
        public async void AdicionaCliente(Cliente cliente)
        {
            try
            {
                // await BuscaCep(cliente.Cep);
                cliente.Logradouro = _endereco != null ? _endereco.logradouro : "";
                cliente.Bairro = _endereco != null ? _endereco.bairro : "";
                cliente.NumeroCasa = _numeroCasa;
                cliente.TelefoneSecundario = _telefoneSecundario == null ? "" : _telefoneSecundario;
                cliente.Inclusao = DateTime.Now;
                cliente.Alteracao = DateTime.Now;
                _clienteReprository.InsertOrReplace(cliente);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }


}


