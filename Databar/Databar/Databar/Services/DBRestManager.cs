using Databar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Services
{
    /// <summary>
    /// DBRestManager is a wrapper-class for managing RestService and allowing database-operations.
    /// </summary>
    public class DBRestManager
    {
        IRestService restService;

        /// <summary>
        /// Constructor that instantiates DBRestManager with a given IRestService.
        /// </summary>
        /// <param name="service">IRestService to be used.</param>
        public DBRestManager(IRestService service)
        {
            restService = service;
        }

        public void SetDBRestManager(IRestService service)
        {
            restService = service;
        }

        public Task<Boolean> AuthenticateAdmin()
        {
            return restService.AuthenticateAdmin();
        }

        /// <summary>
        /// Returns a list of Product-objects in the database.
        /// </summary>
        /// <returns>Corresponding method in RestService, which returns a 
        /// List of type Product, containing all Product-objects in database.</returns>
        public Task<List<Product>> GetProductsAsync()
        {
            return restService.RefreshProductDataAsync();
        }

        /// <summary>
        /// Returns a list of AI-objects in the database.
        /// </summary>
        /// <returns>Corresponding method in RestService, which returns a
        /// List of type AI, containing all AI-objects in database.</returns>
        public Task<List<AI>> GetAIsAsync()
        {
            return restService.RefreshAIDataAsync();
        }

        /// <summary>
        /// Returns a list of BatchBlock-objects in the database.
        /// </summary>
        /// <returns>Corresponding method in RestService, which returns a 
        /// List of type BatchBlock, containing all BatchBlock-objects in database.</returns>
        public Task<List<BatchBlock>> GetBatchBlocksAsync()
        {
            return restService.RefreshBatchDataAsync();
        }

        /// <summary>
        /// Asynchronously saves or updates a Product in the database.
        /// </summary>
        /// <param name="prod">Product-object to be saved or updated.</param>
        /// <param name="isNewItem">True = save, False (default) = update.</param>
        /// <returns>Corresponding method in RestService.</returns>
        public Task SaveProductAsync(Product prod, bool isNewItem = false)
        {
            return restService.SaveProductAsync(prod, isNewItem);
        }

        /// <summary>
        /// Asynchronously saves or updates an AI in the database.
        /// </summary>
        /// <param name="prod">AI-object to be saved or updated.</param>
        /// <param name="isNewItem">True = save, False (default) = update.</param>
        /// <returns>Corresponding method in RestService.</returns>
        public Task SaveAIAsync(AI ai, bool isNewItem = false)
        {
            return restService.SaveAIAsync(ai, isNewItem);
        }

        /// <summary>
        /// Asynchronously saves or updates a BatchBlock in the database.
        /// </summary>
        /// <param name="prod">BatchBlock-object to be saved or updated.</param>
        /// <param name="isNewItem">True = save, False (default) = update.</param>
        /// <returns>Corresponding method in RestService.</returns>
        public Task SaveBatchBlockAsync(BatchBlock batch, bool isNewItem = false)
        {
            return restService.SaveBatchBlockAsync(batch, isNewItem);
        }

        /// <summary>
        /// Deletes a Product-object from the database.
        /// </summary>
        /// <param name="prod">Product to be deleted.</param>
        /// <returns>Corresponding method in RestService, with object's PrimaryKey as parameter.</returns>
        public Task DeleteProductAsync(Product prod)
        {
            return restService.DeleteProductAsync(prod.GTIN.ToString());
        }

        /// <summary>
        /// Deletes an AI-object from the database.
        /// </summary>
        /// <param name="ai">AI to be deleted.</param>
        /// <returns>Corresponding method in RestService, with object's PrimaryKey as parameter.</returns>
        public Task DeleteAIAsync(AI ai)
        {
            return restService.DeleteAIAsync(ai.AInumber.ToString());
        }

        /// <summary>
        /// Deletes a BatchBlock-object from the database,
        /// </summary>
        /// <param name="batch">BatchBlock to be deleted.</param>
        /// <returns>Corresponding method in RestService, with object's PrimaryKey as parameter.</returns>
        public Task DeleteBatchBlockAsync(BatchBlock batch)
        {
            return restService.DeleteBatchBlockAsync(batch.BatchNr.ToString());
        }

        // UPDATE operations needed
    }
}
