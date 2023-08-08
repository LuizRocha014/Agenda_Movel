using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda_Movel.Data.Models.Cummons
{
    public class Core
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }
    }
}
