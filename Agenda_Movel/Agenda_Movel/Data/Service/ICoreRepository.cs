using Agenda_Movel.Data.Models.Cummons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda_Movel.Data.Service
{
   public interface ICoreRepository<T> where T : Core
    {
        T GetById(Guid Id);

        void InsertOrReplace(T Model);

        void InsertOrReplace(List<T> Model);

        List<T> GetAll();

        DateTime? GetLastUpdate();

        void DeleteById(Guid? Id);

        void Delete(T model);

        void DeleteAll(List<T> model);

        void DeleteAll();

        void Update(T model);

        List<T> GetAllAtivos();
    }
}
