using Agenda_Movel.Data.Context;
using Agenda_Movel.Data.Models;
using Agenda_Movel.Data.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda_Movel.Data.Repository
{
    class ClienteRepository: CoreRepository<Cliente>, IClienteReprository
    {
        public ClienteRepository()
        {
            DbContext = DataContext.Current;
        }

        public List<Cliente> GetCLientesOrder()
        {
            try
            {
               var list = _dbContext.Conexao.Query<Cliente>("SELECT * FROM CLIENTE ORDER BY NOME");
                return list;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
