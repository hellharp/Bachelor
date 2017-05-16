using Databar.Models;
using SQLite.Net.Async;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Databar.Services
{
    //https://xamarindevelopervietnam.wordpress.com/2016/01/08/how-to-use-sqliteasync-pcl-in-xamarin-forms/
    [Obsolete("Not used anymore.")]
    public class DB_Service : IDB_Service
    {
        //IRestService restService;

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
            try
            {
                await DbConnection.CreateTableAsync<AI>();
                await DbConnection.CreateTableAsync<Product>();
                await DbConnection.CreateTableAsync<BatchBlock>();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create db fail: " + e.Message);
            }
        }

        // DATABASEOPERASJONER

        // Alle Producter
        public Task<List<Product>> GetProductsAsync()
        {
            return _dbConnection.Table<Product>().ToListAsync();
        }

        //    // Spesifikt Product med id
        //    public Task<Product> GetProductsAsync(int id)
        //    {
        //        return database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        //    }

        //    // Categoryer
        //    public Task<List<CategoryRebate>> GetCategoriesAsync()
        //    {
        //        return database.Table<CategoryRebate>().ToListAsync();
        //    }
        //    // Spesifikt Category med Categorynavn
        //    public Task<CategoryRebate> GetCategoriesAsync(string kat)
        //    {
        //        return database.Table<CategoryRebate>().Where(i => i.Category == kat).FirstOrDefaultAsync();
        //    }

        //    //Lagre
        //    public Task<int> SaveItemAsync(AI identifikator)
        //    {
        //        if (identifikator.AInumber != 0)
        //        {
        //            return database.UpdateAsync(identifikator);
        //        }
        //        else
        //        {
        //            return database.InsertAsync(identifikator);
        //        }
        //    }

        //    public Task<int> SaveItemAsync(Product gtin)
        //    {
        //        if (gtin.GTIN != 0)
        //        {
        //            return database.UpdateAsync(gtin);
        //        }
        //        else
        //        {
        //            return database.InsertAsync(gtin);
        //        }
        //    }

        //    public Task<int> SaveItemAsync(CategoryRebate kr)
        //    {
        //        if (kr.Category != "")
        //        {
        //            return database.UpdateAsync(kr);
        //        }
        //        else
        //        {
        //            return database.InsertAsync(kr);
        //        }
        //    }

        //    // Slett
        //    public Task<int> DeleteItemAsync(AI identifikator)
        //    {
        //        return database.DeleteAsync(identifikator);
        //    }
        //    public Task<int> DeleteItemAsync(Product prod)
        //    {
        //        return database.DeleteAsync(prod);
        //    }
        //    public Task<int> DeleteItemAsync(CategoryRebate kr)
        //    {
        //        return database.DeleteAsync(kr);
        //    }



    }
}
