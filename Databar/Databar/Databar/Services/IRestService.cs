using Databar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Services
{
    /// <summary>
    /// Interface for REST service.
    /// </summary>
    public interface IRestService
    {
        //Authenticate
        Task<Boolean> AuthenticateAdmin();

        //Product
        Task<List<Product>> RefreshProductDataAsync();

        Task SaveProductAsync(Product prod, bool isNewItem);

        Task DeleteProductAsync(string id);

        //AI
        Task<List<AI>> RefreshAIDataAsync();

        Task SaveAIAsync(AI ai, bool isNewItem);

        Task DeleteAIAsync(string id);

        //BatchBlock
        Task<List<BatchBlock>> RefreshBatchDataAsync();

        Task SaveBatchBlockAsync(BatchBlock batch, bool isNewItem);

        Task DeleteBatchBlockAsync(string id);
    }
}
