using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Databar.Models;
using Databar.ViewModels;
using Databar.Services;
using Microsoft.Pex.Framework.Generated;
// <copyright file="CartViewModelTest.CartListGet.g.cs">Copyright ©  2014</copyright>
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
public void CartListGet708()
{
    using (PexTraceListenerContext.Create())
    {
      CartServices cartServices;
      CartViewModel cartViewModel;
      ObservableCollection<Product> observableCollection;
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("", (string)null);
      observableCollection = this.CartListGet(cartViewModel);
      Assert.IsNotNull((object)observableCollection);
      Assert.IsNotNull((object)cartViewModel);
      Assert.IsNotNull(cartViewModel.CartList);
      Assert.IsTrue(object.ReferenceEquals
                        (cartViewModel.CartList, (object)observableCollection));
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
public void CartListGet70801()
{
    using (PexTraceListenerContext.Create())
    {
      CartServices cartServices;
      CartViewModel cartViewModel;
      ObservableCollection<Product> observableCollection;
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("17", (string)null);
      observableCollection = this.CartListGet(cartViewModel);
      Assert.IsNotNull((object)observableCollection);
      Assert.IsNotNull((object)cartViewModel);
      Assert.IsNotNull(cartViewModel.CartList);
      Assert.IsTrue(object.ReferenceEquals
                        (cartViewModel.CartList, (object)observableCollection));
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
public void CartListGet70802()
{
    using (PexTraceListenerContext.Create())
    {
      ResourceDictionary resourceDictionary;
      CartServices cartServices;
      CartViewModel cartViewModel;
      ObservableCollection<Product> observableCollection;
      resourceDictionary = new ResourceDictionary();
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = resourceDictionary;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = "";
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("", (string)null);
      observableCollection = this.CartListGet(cartViewModel);
      Assert.IsNotNull((object)observableCollection);
      Assert.IsNotNull((object)cartViewModel);
      Assert.IsNotNull(cartViewModel.CartList);
      Assert.IsTrue(object.ReferenceEquals
                        (cartViewModel.CartList, (object)observableCollection));
    }
}
    }
}
