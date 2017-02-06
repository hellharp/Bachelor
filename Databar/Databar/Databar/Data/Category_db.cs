using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Databar_skanner.Models;
using SQLiteNetExtensions;

namespace Databar.Data
{
    public class Category_db
    {
        readonly SQLiteAsyncConnection database;

        public Category_db(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<CategoryRebate>().Wait();
        }

        public Task<List<CategoryRebate>> GetItemsAsync()
        {
            return database.Table<CategoryRebate>().ToListAsync();
        }

        public Task<CategoryRebate> GetItemAsync(int id)
        {
            return database.Table<CategoryRebate>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CategoryRebate id)
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

        public Task<int> DeleteItemAsync(CategoryRebate id)
        {
            return database.DeleteAsync(id);
        }
    }
}
