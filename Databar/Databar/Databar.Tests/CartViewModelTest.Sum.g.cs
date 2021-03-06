using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using Databar.ViewModels;
using Databar.Services;
using Microsoft.Pex.Framework.Generated;
// <copyright file="CartViewModelTest.Sum.g.cs">Copyright ©  2014</copyright>
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
[PexRaisedException(typeof(NullReferenceException))]
public void SumThrowsNullReferenceException189()
{
    using (PexTraceListenerContext.Create())
    {
      CartServices cartServices;
      CartViewModel cartViewModel;
      decimal d;
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("", (string)null);
      d = this.Sum(cartViewModel);
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void SumThrowsNullReferenceException18901()
{
    using (PexTraceListenerContext.Create())
    {
      CartServices cartServices;
      CartViewModel cartViewModel;
      decimal d;
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("17", (string)null);
      d = this.Sum(cartViewModel);
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void SumThrowsNullReferenceException18902()
{
    using (PexTraceListenerContext.Create())
    {
      ResourceDictionary resourceDictionary;
      CartServices cartServices;
      CartViewModel cartViewModel;
      decimal d;
      resourceDictionary = new ResourceDictionary();
      cartServices = new CartServices();
      ((VisualElement)cartServices).Resources = resourceDictionary;
      ((Element)cartServices).AutomationId = (string)null;
      ((Element)cartServices).StyleId = (string)null;
      ((Element)cartServices).Parent = (Element)null;
      ((VisualElement)cartServices).BatchBegin();
      cartViewModel = new CartViewModel(cartServices);
      cartViewModel.GetGTIN("", (string)null);
      d = this.Sum(cartViewModel);
    }
}
    }
}
