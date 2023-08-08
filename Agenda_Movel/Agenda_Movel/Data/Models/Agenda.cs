using Agenda_Movel.Data.Models.Cummons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Agenda_Movel.Data.Models
{
    public class Agenda : Sincronismo
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Titulo { get; set; }
        public string Obaservacao { get; set; }
        public Color Cores { get; set; }
    }
}
