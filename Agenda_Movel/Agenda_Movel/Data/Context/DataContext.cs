using Agenda_Movel.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Agenda_Movel.Data.Context
{
    public class DataContext
    {

        private static SQLiteConnection _sqlLiteConnection;

        public static DataContext _lazy;

        public static DataContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new DataContext();

                return _lazy;
            }
        }


        public DataContext()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");
            _sqlLiteConnection = new SQLiteConnection(databasePath);

            _sqlLiteConnection.CreateTable<Agenda>();
            _sqlLiteConnection.CreateTable<Cliente>();
        }


        public SQLiteConnection Conexao { get { return _sqlLiteConnection; } set { _sqlLiteConnection = value; } }
    }
}
