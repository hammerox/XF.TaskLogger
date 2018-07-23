using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskLogger.Interfaces;
using TaskLogger.Models;
using Xamarin.Forms;

namespace TaskLogger.Repositories
{
    public class ActivityRepostory
    {
        private ActivityRepostory() { }

        private static SQLiteConnection database;
        private static readonly ActivityRepostory instance = new ActivityRepostory();
        public static ActivityRepostory Instance
        {
            get
            {
                if (database == null)
                {
                    database = DependencyService.Get<IDependencyServiceSQLite>().GetConexao();
                    database.CreateTable<Activity>();
                }
                return instance;
            }
        }

        static object locker = new object();

        public static int SalvarActivity(Activity activity)
        {
            lock (locker)
            {
                if (activity.Id != 0)
                {
                    database.Update(activity);
                    return activity.Id;
                }
                else return database.Insert(activity);
            }
        }

        public static IEnumerable<Activity> GetActivities()
        {
            lock (locker)
            {
                return (from c in database.Table<Activity>()
                        select c).ToList();
            }
        }

        public static Activity GetActivity(int Id)
        {
            lock (locker)
            {
                // return database.Query<Aluno>("SELECT * FROM [Aluno] WHERE [Id] = " + Id).FirstOrDefault();
                return database.Table<Activity>().Where(c => c.Id == Id).FirstOrDefault();
            }
        }

        public static int RemoverActivity(int Id)
        {
            lock (locker)
            {
                return database.Delete<Activity>(Id);
            }
        }
    }
}
