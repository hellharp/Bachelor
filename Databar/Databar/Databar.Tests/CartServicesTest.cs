using System.Collections.Generic;
using System.Collections.ObjectModel;
using Databar.Models;
// <copyright file="CartServicesTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Services.Tests
{
    [TestClass]
    [PexClass(typeof(CartServices))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CartServicesTest
    {

        [PexMethod]
        public CartServices Constructor()
        {
            CartServices target = new CartServices();
            return target;
            // TODO: add assertions to method CartServicesTest.Constructor()
        }

        [PexMethod]
        public void Add([PexAssumeUnderTest]CartServices target, Product e)
        {
            target.Add(e);
            // TODO: add assertions to method CartServicesTest.Add(CartServices, Product)
        }

        [PexMethod]
        public void RemoveProduct([PexAssumeUnderTest]CartServices target, Product t)
        {
            target.RemoveProduct(t);
            // TODO: add assertions to method CartServicesTest.RemoveProduct(CartServices, Product)
        }

        [PexMethod]
        public ObservableCollection<Product> ResetCartlist([PexAssumeUnderTest]CartServices target)
        {
            ObservableCollection<Product> result = target.ResetCartlist();
            return result;
            // TODO: add assertions to method CartServicesTest.ResetCartlist(CartServices)
        }

        [PexMethod]
        public decimal Sum([PexAssumeUnderTest]CartServices target, List<string> dateList)
        {
            decimal result = target.Sum(dateList);
            return result;
            // TODO: add assertions to method CartServicesTest.Sum(CartServices, List`1<String>)
        }

        [PexMethod]
        public ObservableCollection<Product> getCartList([PexAssumeUnderTest]CartServices target)
        {
            ObservableCollection<Product> result = target.getCartList();
            return result;
            // TODO: add assertions to method CartServicesTest.getCartList(CartServices)
        }
    }
}
