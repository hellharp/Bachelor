using Microsoft.VisualStudio.TestTools.UnitTesting;
using Databar.Models;
using Databar.ViewModels;
using Databar.Services;
using Xamarin.Forms;
using Microsoft.Pex.Framework.Generated;
// <copyright file="CartViewModelTest.RemoveProduct.g.cs">Copyright ©  2014</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Databar.ViewModels.Tests
{
    public partial class CartViewModelTest
    {

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
public void RemoveProduct95502()
{
    using (PexTraceListenerContext.Create())
    {
      ResourceDictionary resourceDictionary;
      CartServices cartServices;
      CartViewModel cartViewModel;
      resourceDictionary = new ResourceDictionary();
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = resourceDictionary;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("", (string)null);
      this.RemoveProduct(cartViewModel, (Product)null);
      Assert.IsNotNull((object)cartViewModel);
      Assert.IsNotNull(cartViewModel.CartList);
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
public void RemoveProduct955()
{
    using (PexTraceListenerContext.Create())
    {
      CartServices cartServices;
      CartViewModel cartViewModel;
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("", (string)null);
      this.RemoveProduct(cartViewModel, (Product)null);
      Assert.IsNotNull((object)cartViewModel);
      Assert.IsNotNull(cartViewModel.CartList);
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
public void RemoveProduct95501()
{
    using (PexTraceListenerContext.Create())
    {
      CartServices cartServices;
      CartViewModel cartViewModel;
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("15", (string)null);
      this.RemoveProduct(cartViewModel, (Product)null);
      Assert.IsNotNull((object)cartViewModel);
      Assert.IsNotNull(cartViewModel.CartList);
    }
}
    }
}
