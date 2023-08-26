using Agenda_Movel.Data.Models.Cummons;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Agenda_Movel.Data.Models
{
    public class Agenda : Sincronismo
    {
        public DateTime DataInicial { get; set; }
        public TimeSpan DataFinal { get; set; }
        public string Titulo { get; set; }
        public string Obaservacao { get; set; }
        public StatusAgenda Status { get; set; }
        
        [Ignore]
        public string CorStatus
        {
            get
            {
                var cor = "";
                switch (Status)
                {
                    case StatusAgenda.Agendado:
                        cor = "#32a852";
                        break;

                    case StatusAgenda.Finalizado:
                        cor = "#b88907";
                        break;

                    case StatusAgenda.Cancelado:
                        cor = "#d9071c";
                        break;

                    case StatusAgenda.Remarcado:
                        cor = "#7707b8";
                        break;
                    default:
                        cor = "#939194";
                        break;
                }
                return cor;
            }
        }
       
       
        public enum StatusAgenda
        {
            Agendado,
            Finalizado,
            Cancelado,
            Remarcado,
        };
    }
}
