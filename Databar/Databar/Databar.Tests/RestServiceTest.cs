using System.Collections.Generic;
using Databar.Models;
using System.Threading.Tasks;
// <copyright file="RestServiceTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Services.Tests
{
    [TestClass]
    [PexClass(typeof(RestService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RestServiceTest
    {

        [PexMethod]
        public Task SaveProductAsync(
            [PexAssumeUnderTest]RestService target,
            Product prod,
            bool isNewItem
        )
        {
            Task result = target.SaveProductAsync(prod, isNewItem);
            return result;
            // TODO: add assertions to method RestServiceTest.SaveProductAsync(RestService, Product, Boolean)
        }

        [PexMethod]
        public Task SaveBatchBlockAsync(
            [PexAssumeUnderTest]RestService target,
            BatchBlock batch,
            bool isNewItem
        )
        {
            Task result = target.SaveBatchBlockAsync(batch, isNewItem);
            return result;
            // TODO: add assertions to method RestServiceTest.SaveBatchBlockAsync(RestService, BatchBlock, Boolean)
        }

        [PexMethod]
        public Task SaveAIAsync(
            [PexAssumeUnderTest]RestService target,
            AI ai,
            bool isNewItem
        )
        {
            Task result = target.SaveAIAsync(ai, isNewItem);
            return result;
            // TODO: add assertions to method RestServiceTest.SaveAIAsync(RestService, AI, Boolean)
        }

        [PexMethod]
        public Task<List<Product>> RefreshProductDataAsync([PexAssumeUnderTest]RestService target)
        {
            Task<List<Product>> result = target.RefreshProductDataAsync();
            return result;
            // TODO: add assertions to method RestServiceTest.RefreshProductDataAsync(RestService)
        }

        [PexMethod]
        public Task<List<BatchBlock>> RefreshBatchDataAsync([PexAssumeUnderTest]RestService target)
        {
            Task<List<BatchBlock>> result = target.RefreshBatchDataAsync();
            return result;
            // TODO: add assertions to method RestServiceTest.RefreshBatchDataAsync(RestService)
        }

        [PexMethod]
        public Task<List<AI>> RefreshAIDataAsync([PexAssumeUnderTest]RestService target)
        {
            Task<List<AI>> result = target.RefreshAIDataAsync();
            return result;
            // TODO: add assertions to method RestServiceTest.RefreshAIDataAsync(RestService)
        }

        [PexMethod]
        public Task DeleteProductAsync([PexAssumeUnderTest]RestService target, string id)
        {
            Task result = target.DeleteProductAsync(id);
            return result;
            // TODO: add assertions to method RestServiceTest.DeleteProductAsync(RestService, String)
        }

        [PexMethod]
        public Task DeleteBatchBlockAsync([PexAssumeUnderTest]RestService target, string id)
        {
            Task result = target.DeleteBatchBlockAsync(id);
            return result;
            // TODO: add assertions to method RestServiceTest.DeleteBatchBlockAsync(RestService, String)
        }

        [PexMethod]
        public Task DeleteAIAsync([PexAssumeUnderTest]RestService target, string id)
        {
            Task result = target.DeleteAIAsync(id);
            return result;
            // TODO: add assertions to method RestServiceTest.DeleteAIAsync(RestService, String)
        }

        [PexMethod]
        public RestService Constructor()
        {
            RestService target = new RestService();
            return target;
            // TODO: add assertions to method RestServiceTest.Constructor()
        }
    }
}
