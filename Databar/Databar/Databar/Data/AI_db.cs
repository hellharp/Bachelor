using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Databar_skanner.Models;
using SQLiteNetExtensions;


namespace Databar.Data
{
	public class AI_db
	{
		readonly SQLiteAsyncConnection database;

		public AI_db(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<AI>().Wait();
		}

		public Task<List<AI>> GetItemsAsync()
		{
			return database.Table<AI>().ToListAsync();
		}

		public Task<AI> GetItemAsync(int id)
		{
			return database.Table<AI>().Where(i => i.AInumber == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(AI identifikator)
		{
			if (identifikator.AInumber != 0)
			{
				return database.UpdateAsync(identifikator);
			}
			else {
				return database.InsertAsync(identifikator);
			}
		}

		public Task<int> DeleteItemAsync(AI identifikator)
		{
			return database.DeleteAsync(identifikator);
		}
	}
}

