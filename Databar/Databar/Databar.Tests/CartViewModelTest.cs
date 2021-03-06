using System.Collections.ObjectModel;
using Databar.Services;
using Databar.Models;
using System.Threading.Tasks;
// <copyright file="CartViewModelTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.ViewModels;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.ViewModels.Tests
{
    [TestClass]
    [PexClass(typeof(CartViewModel))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CartViewModelTest
    {

        [PexMethod]
        public decimal Sum([PexAssumeUnderTest]CartViewModel target)
        {
            decimal result = target.Sum();
            return result;
            // TODO: add assertions to method CartViewModelTest.Sum(CartViewModel)
        }

        [PexMethod]
        public Task<string> StartZXing(
            [PexAssumeUnderTest]CartViewModel target,
            object sender,
            EventArgs e
        )
        {
            Task<string> result = target.StartZXing(sender, e);
            return result;
            // TODO: add assertions to method CartViewModelTest.StartZXing(CartViewModel, Object, EventArgs)
        }

        [PexMethod]
        public void SlettDateList([PexAssumeUnderTest]CartViewModel target)
        {
            target.SlettDateList();
            // TODO: add assertions to method CartViewModelTest.SlettDateList(CartViewModel)
        }

        [PexMethod]
        public void ResetCartlist([PexAssumeUnderTest]CartViewModel target)
        {
            target.ResetCartlist();
            // TODO: add assertions to method CartViewModelTest.ResetCartlist(CartViewModel)
        }

        [PexMethod]
        public void RemoveProduct([PexAssumeUnderTest]CartViewModel target, Product t)
        {
            target.RemoveProduct(t);
            // TODO: add assertions to method CartViewModelTest.RemoveProduct(CartViewModel, Product)
        }

        [PexMethod]
        public void GetGTIN(
            [PexAssumeUnderTest]CartViewModel target,
            string AI,
            string Code
        )
        {
            target.GetGTIN(AI, Code);
            // TODO: add assertions to method CartViewModelTest.GetGTIN(CartViewModel, String, String)
        }

        [PexMethod]
        public CartServices GetCartService([PexAssumeUnderTest]CartViewModel target)
        {
            CartServices result = target.GetCartService();
            return result;
            // TODO: add assertions to method CartViewModelTest.GetCartService(CartViewModel)
        }

        [PexMethod]
        public CartViewModel Constructor(CartServices _cartServices)
        {
            CartViewModel target = new CartViewModel(_cartServices);
            return target;
            // TODO: add assertions to method CartViewModelTest.Constructor(CartServices)
        }

        [PexMethod]
        public void CartListSet([PexAssumeUnderTest]CartViewModel target, ObservableCollection<Product> value)
        {
            target.CartList = value;
            // TODO: add assertions to method CartViewModelTest.CartListSet(CartViewModel, ObservableCollection`1<Product>)
        }

        [PexMethod]
        public ObservableCollection<Product> CartListGet([PexAssumeUnderTest]CartViewModel target)
        {
            ObservableCollection<Product> result = target.CartList;
            return result;
            // TODO: add assertions to method CartViewModelTest.CartListGet(CartViewModel)
        }

        [PexMethod]
        public string AddBarcode([PexAssumeUnderTest]CartViewModel target, string barcode)
        {
            string result = target.AddBarcode(barcode);
            return result;
            // TODO: add assertions to method CartViewModelTest.AddBarcode(CartViewModel, String)
        }
    }
}
