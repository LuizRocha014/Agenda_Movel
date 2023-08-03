using Agenda_Movel.Data.Interface;
using Agenda_Movel.Droid.Utils;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(DtContext))]
namespace Agenda_Movel.Droid.Utils
{
    public class DtContext : IDbPath
    {

        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db3");
        }


    }
}