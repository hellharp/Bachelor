using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databar.Models;

namespace Databar.Services
{
    public class RestService : IRestService
    {
        public Task DeleteAIAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBatchBlockAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AI>> RefreshAIDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BatchBlock>> RefreshBatchDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> RefreshProductDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAIAsync(AI ai, bool isNewItem)
        {
            throw new NotImplementedException();
        }

        public Task SaveBatchBlockAsync(BatchBlock batch, bool isNewItem)
        {
            throw new NotImplementedException();
        }

        public Task SaveProductAsync(Product prod, bool isNewItem)
        {
            throw new NotImplementedException();
        }
    }
}
