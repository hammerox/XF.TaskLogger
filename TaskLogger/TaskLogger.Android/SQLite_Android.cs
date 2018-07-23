using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TaskLogger.Droid;
using TaskLogger.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace TaskLogger.Droid
{
    public class SQLite_Android : IDependencyServiceSQLite
    {
        public SQLite_Android() { }

        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "activitydb.db";
            string caminho = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var local = Path.Combine(caminho, arquivodb);

            var conexao = new SQLite.SQLiteConnection(local);
            return conexao;
        }
    }
}