using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Databar_skanner.Models;
using SQLiteNetExtensions;

namespace Databar.Data
{
    public class Kategori_db
    {
        readonly SQLiteAsyncConnection database;

        public Kategori_db(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<KategoriRabatt>().Wait();
        }

        public Task<List<KategoriRabatt>> GetItemsAsync()
        {
            return database.Table<KategoriRabatt>().ToListAsync();
        }

        public Task<KategoriRabatt> GetItemAsync(int id)
        {
            return database.Table<KategoriRabatt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(KategoriRabatt id)
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

        public Task<int> DeleteItemAsync(KategoriRabatt id)
        {
            return database.DeleteAsync(id);
        }
    }
}
