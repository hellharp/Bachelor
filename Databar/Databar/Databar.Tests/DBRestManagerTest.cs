using System.Collections.Generic;
using Databar.Models;
using System.Threading.Tasks;
// <copyright file="DBRestManagerTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Services.Tests
{
    [TestClass]
    [PexClass(typeof(DBRestManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DBRestManagerTest
    {

        [PexMethod]
        public Task SaveProductAsync(
            [PexAssumeUnderTest]DBRestManager target,
            Product prod,
            bool isNewItem
        )
        {
            Task result = target.SaveProductAsync(prod, isNewItem);
            return result;
            // TODO: add assertions to method DBRestManagerTest.SaveProductAsync(DBRestManager, Product, Boolean)
        }

        [PexMethod]
        public Task SaveBatchBlockAsync(
            [PexAssumeUnderTest]DBRestManager target,
            BatchBlock batch,
            bool isNewItem
        )
        {
            Task result = target.SaveBatchBlockAsync(batch, isNewItem);
            return result;
            // TODO: add assertions to method DBRestManagerTest.SaveBatchBlockAsync(DBRestManager, BatchBlock, Boolean)
        }

        [PexMethod]
        public Task SaveAIAsync(
            [PexAssumeUnderTest]DBRestManager target,
            AI ai,
            bool isNewItem
        )
        {
            Task result = target.SaveAIAsync(ai, isNewItem);
            return result;
            // TODO: add assertions to method DBRestManagerTest.SaveAIAsync(DBRestManager, AI, Boolean)
        }

        [PexMethod]
        public Task<List<Product>> GetProductsAsync([PexAssumeUnderTest]DBRestManager target)
        {
            Task<List<Product>> result = target.GetProductsAsync();
            return result;
            // TODO: add assertions to method DBRestManagerTest.GetProductsAsync(DBRestManager)
        }

        [PexMethod]
        public Task<List<BatchBlock>> GetBatchBlocksAsync([PexAssumeUnderTest]DBRestManager target)
        {
            Task<List<BatchBlock>> result = target.GetBatchBlocksAsync();
            return result;
            // TODO: add assertions to method DBRestManagerTest.GetBatchBlocksAsync(DBRestManager)
        }

        [PexMethod]
        public Task<List<AI>> GetAIsAsync([PexAssumeUnderTest]DBRestManager target)
        {
            Task<List<AI>> result = target.GetAIsAsync();
            return result;
            // TODO: add assertions to method DBRestManagerTest.GetAIsAsync(DBRestManager)
        }

        [PexMethod]
        public Task DeleteProductAsync([PexAssumeUnderTest]DBRestManager target, Product prod)
        {
            Task result = target.DeleteProductAsync(prod);
            return result;
            // TODO: add assertions to method DBRestManagerTest.DeleteProductAsync(DBRestManager, Product)
        }

        [PexMethod]
        public Task DeleteBatchBlockAsync([PexAssumeUnderTest]DBRestManager target, BatchBlock batch)
        {
            Task result = target.DeleteBatchBlockAsync(batch);
            return result;
            // TODO: add assertions to method DBRestManagerTest.DeleteBatchBlockAsync(DBRestManager, BatchBlock)
        }

        [PexMethod]
        public Task DeleteAIAsync([PexAssumeUnderTest]DBRestManager target, AI ai)
        {
            Task result = target.DeleteAIAsync(ai);
            return result;
            // TODO: add assertions to method DBRestManagerTest.DeleteAIAsync(DBRestManager, AI)
        }

        [PexMethod]
        public DBRestManager Constructor(IRestService service)
        {
            DBRestManager target = new DBRestManager(service);
            return target;
            // TODO: add assertions to method DBRestManagerTest.Constructor(IRestService)
        }
    }
}
