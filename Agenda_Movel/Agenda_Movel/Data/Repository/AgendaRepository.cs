using Agenda_Movel.Data.Context;
using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda_Movel.Data.Repository
{
     class AgendaRepository : CoreRepository<Agenda>, IAgendasRepository
    {
        public AgendaRepository()
        {
            DbContext = DataContext.Current;
        }
    }
}
