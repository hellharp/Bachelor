// <copyright file="ProductTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Models.Tests
{
    [TestClass]
    [PexClass(typeof(Product))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ProductTest
    {

        [PexMethod]
        public void ProductNameAndPriceSet([PexAssumeUnderTest]Product target, string value)
        {
            target.ProductNameAndPrice = value;
            // TODO: add assertions to method ProductTest.ProductNameAndPriceSet(Product, String)
        }
    }
}
