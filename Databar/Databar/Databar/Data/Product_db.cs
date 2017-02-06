using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Databar_skanner.Models;
using SQLiteNetExtensions;

namespace Databar.Data
{
    public class Product_db
    {
        readonly SQLiteAsyncConnection database;

        public Product_db(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Product>> GetItemsAsync()
        {
            return database.Table<Product>().ToListAsync();
        }

        public Task<Product> GetItemAsync(int id)
        {
            return database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Product id)
        {
            if (id.ID != 0)
            {
                return database.UpdateAsync(id);
            }
            else
            {
                return database.InsertAsync(id);
            }
        }

        public Task<int> DeleteItemAsync(Product identifikator)
        {
            return database.DeleteAsync(identifikator);
        }
    }
}

