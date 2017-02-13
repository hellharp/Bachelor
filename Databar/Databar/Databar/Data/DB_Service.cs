using Databar_skanner.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Databar.Data
{
    //https://xamarindevelopervietnam.wordpress.com/2016/01/08/how-to-use-sqliteasync-pcl-in-xamarin-forms/
    public class DB_Service : IDB_Service
    {
        private static readonly Lazy<DB_Service> Lazy =
        new Lazy<DB_Service>(() => new DB_Service());

        public static IDB_Service Instance => Lazy.Value;

        private DB_Service()
        {
        }

        private SQLiteAsyncConnection _dbConnection;
        public SQLiteAsyncConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    LazyInitializer.EnsureInitialized(ref _dbConnection, DependencyService.Get<IFileHelper>().GetAsyncConnection);
                }

                return _dbConnection;
            }
        }

        public async void CreateDbIfNotExist()
        {
            await DbConnection.CreateTableAsync<AI>();
            Debug.WriteLine("Create db success!");
        }
    }
}
