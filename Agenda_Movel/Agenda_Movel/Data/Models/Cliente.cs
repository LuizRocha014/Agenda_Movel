using Agenda_Movel.Data.Models.Cummons;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Agenda_Movel.Data.Models
{
    class Cliente : Sincronismo
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string NumeroCasa { get; set; }
        public string TelefonePrimario { get; set; }
        public string TelefoneSecundario { get; set; }

        [Ignore, JsonIgnore]
        public virtual Endereco Endereco { get; set; }

        [Ignore]
        public string NomeSobrenomeFormat {
            get { return Nome + " " +Sobrenome; }
        }
        [Ignore]
        public string EnderecoFormatado
        {
            get { return Logradouro + " " + NumeroCasa; }
        }
        [Ignore]
        public string TelefoneFormatado
        {
            get { 
                
                var tel = new StringBuilder(TelefonePrimario);

                tel.Insert(0, "(");
                tel.Insert(3, ")");
                tel.Insert(4, " ");
                tel.Insert(6, " ");
                tel.Insert(11, "-");
                return  tel.ToString(); }
        }

    }
}
