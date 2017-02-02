using Databar_skanner.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Data
{
    public class Databar_DB
    {
        readonly SQLiteAsyncConnection database;

        public Databar_DB(string dbPath)
        {
            // DB connection. SQLiteConnection oppretter DB dersom den ikke finnes.
            database = new SQLiteAsyncConnection(dbPath);
            // Tabeller. CreateTable oppretter tabeller dersom de ikke finnes.
            database.CreateTableAsync<AI>().Wait();
            database.CreateTableAsync<CategoryRebate>().Wait();
            database.CreateTableAsync<Product>().Wait();

            // Opprett testtabeller
            AI gtin = new AI();
            gtin.AInumber = 01;
            gtin.AIdescription = "Global Trade Identification Number";
            database.InsertAsync(gtin);

            CategoryRebate melk = new CategoryRebate();
            melk.Category = "Melk";
            melk.TwoDaysRebate = 0.10;
            melk.OneDayRebate = 0.20;
            melk.LastDayRebate = 0.50;
            database.InsertAsync(melk);

            Product prod = new Product();
            prod.GTIN = 12345678901234;
            prod.ProductName = "Tine Ekstra Lett 1 liter";
            prod.Category = GetCategoriesAsync("Melk").ToString();
            prod.BestBeforeDate = new DateTime(170612); // yymmdd
        }

        // Alle Producter
        public Task<List<Product>> GetProductsAsync()
        {
            return database.Table<Product>().ToListAsync();
        }

        // Spesifikt Product med id
        public Task<Product> GetProductsAsync(int id)
        {
            return database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        // Categoryer
        public Task<List<CategoryRebate>> GetCategoriesAsync()
        {
            return database.Table<CategoryRebate>().ToListAsync();
        }
        // Spesifikt Category med Categorynavn
        public Task<CategoryRebate> GetCategoriesAsync(string kat)
        {
            return database.Table<CategoryRebate>().Where(i => i.Category == kat).FirstOrDefaultAsync();
        }

        //Lagre
        public Task<int> SaveItemAsync(AI identifikator)
        {
            if (identifikator.AInumber != 0)
            {
                return database.UpdateAsync(identifikator);
            }
            else
            {
                return database.InsertAsync(identifikator);
            }
        }

        public Task<int> SaveItemAsync(Product gtin)
        {
            if (gtin.GTIN != 0)
            {
                return database.UpdateAsync(gtin);
            }
            else
            {
                return database.InsertAsync(gtin);
            }
        }

        public Task<int> SaveItemAsync(CategoryRebate kr)
        {
            if (kr.Category != "")
            {
                return database.UpdateAsync(kr);
            }
            else
            {
                return database.InsertAsync(kr);
            }
        }
        
        // Slett
        public Task<int> DeleteItemAsync(AI identifikator)
        {
            return database.DeleteAsync(identifikator);
        }
        public Task<int> DeleteItemAsync(Product prod)
        {
            return database.DeleteAsync(prod);
        }
        public Task<int> DeleteItemAsync(CategoryRebate kr)
        {
            return database.DeleteAsync(kr);
        }
    }
}
