using Databar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Services
{
    public class DBRestManager
    {
        IRestService restService;

        public DBRestManager(IRestService service)
        {
            restService = service;
        }
        
        // Get Lists
        public Task<List<Product>> GetProductsAsync()
        {
            return restService.RefreshProductDataAsync();
        }

        public Task<List<AI>> GetAIsAsync()
        {
            return restService.RefreshAIDataAsync();
        }

        public Task<List<BatchBlock>> GetBatchBlocksAsync()
        {
            return restService.RefreshBatchDataAsync();
        }

        // Save operations. isNewItem = false -> PUT, true -> PUSH
        public Task SaveProductAsync(Product prod, bool isNewItem = false)
        {
            return restService.SaveProductAsync(prod, isNewItem);
        }

        public Task SaveAIAsync(AI ai, bool isNewItem = false)
        {
            return restService.SaveAIAsync(ai, isNewItem);
        }

        public Task SaveBatchBlockAsync(BatchBlock batch, bool isNewItem = false)
        {
            return restService.SaveBatchBlockAsync(batch, isNewItem);
        }

        // Delete operations

        public Task DeleteProductAsync(Product prod)
        {
            return restService.DeleteProductAsync(prod.GTIN.ToString());
        }

        public Task DeleteAIAsync(AI ai)
        {
            return restService.DeleteAIAsync(ai.AInumber.ToString());
        }

        public Task DeleteBatchBlockAsync(BatchBlock batch)
        {
            return restService.DeleteBatchBlockAsync(batch.BatchNr.ToString());
        }

        // UPDATE operations needed
    }
}
