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
            // DB connection
            database = new SQLiteAsyncConnection(dbPath);
            // Tabeller
            database.CreateTableAsync<AI>().Wait();
            database.CreateTableAsync<KategoriRabatt>().Wait();
            database.CreateTableAsync<Produkt>().Wait();

            // Opprett testtabeller
            AI gtin = new AI();
            gtin.AInumber = 01;
            gtin.AIdescription = "Global Trade Identification Number";
            database.InsertAsync(gtin);

            KategoriRabatt melk = new KategoriRabatt();
            melk.Kategori = "Melk";
            melk.ToDagerRabatt = 0.10;
            melk.EnDagRabatt = 0.20;
            melk.SisteDagRabatt = 0.50;
            database.InsertAsync(melk);

            Produkt prod = new Produkt();
            prod.GTIN = 12345678901234;
            prod.Produktnavn = "Tine Ekstra Lett 1 liter";
            prod.Kategori = GetCategoriesAsync("Melk").ToString();
            prod.UtlopsDato = new DateTime(170612); // yymmdd
        }

        // Alle produkter
        public Task<List<Produkt>> GetProductsAsync()
        {
            return database.Table<Produkt>().ToListAsync();
        }

        // Spesifikt produkt med id
        public Task<Produkt> GetProductsAsync(int id)
        {
            return database.Table<Produkt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        // Kategorier
        public Task<List<KategoriRabatt>> GetCategoriesAsync()
        {
            return database.Table<KategoriRabatt>().ToListAsync();
        }
        // Spesifikt kategori med kategorinavn
        public Task<KategoriRabatt> GetCategoriesAsync(string kat)
        {
            return database.Table<KategoriRabatt>().Where(i => i.Kategori == kat).FirstOrDefaultAsync();
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

        public Task<int> SaveItemAsync(Produkt gtin)
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

        public Task<int> SaveItemAsync(KategoriRabatt kr)
        {
            if (kr.Kategori != "")
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
        public Task<int> DeleteItemAsync(Produkt prod)
        {
            return database.DeleteAsync(prod);
        }
        public Task<int> DeleteItemAsync(KategoriRabatt kr)
        {
            return database.DeleteAsync(kr);
        }
    }
}
