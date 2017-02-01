using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Databar_skanner.Models;
using SQLiteNetExtensions;

namespace Databar.Data
{
    public class Produkt_db
    {
        readonly SQLiteAsyncConnection database;

        public Produkt_db(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Produkt>().Wait();
        }

        public Task<List<Produkt>> GetItemsAsync()
        {
            return database.Table<Produkt>().ToListAsync();
        }

        public Task<Produkt> GetItemAsync(int id)
        {
            return database.Table<Produkt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Produkt id)
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

        public Task<int> DeleteItemAsync(Produkt identifikator)
        {
            return database.DeleteAsync(identifikator);
        }
    }
}

