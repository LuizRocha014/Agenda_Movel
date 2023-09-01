using Agenda_Movel.Data.Models.Cummons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda_Movel.Data.Models
{
    class Cliente : Sincronismo
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string NumeroCasa { get; set; }
        public string TelefonePrimario { get; set; }
        public string TelefoneSecundario { get; set; }


    }
}
