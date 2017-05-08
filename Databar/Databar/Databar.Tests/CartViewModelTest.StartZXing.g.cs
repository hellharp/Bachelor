using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using System.Threading.Tasks;
using Databar.ViewModels;
using Databar.Services;
using Microsoft.Pex.Framework.Generated;
// <copyright file="CartViewModelTest.StartZXing.g.cs">Copyright ©  2014</copyright>
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
public void StartZXing108()
{
    using (PexTraceListenerContext.Create())
    {
      using (PexDisposableContext disposables = PexDisposableContext.Create())
      {
        CartServices cartServices;
        CartViewModel cartViewModel;
        Task<string> task;
        cartServices = new CartServices();
        ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
        ((Element)cartServices).AutomationId = (string)null;
        ((Element)cartServices).StyleId = (string)null;
        ((Element)cartServices).Parent = (Element)null;
        ((VisualElement)cartServices).BatchBegin();
        cartViewModel = new CartViewModel(cartServices);
        cartViewModel.GetGTIN("", (string)null);
        task = this.StartZXing(cartViewModel, (object)null, (EventArgs)null);
        disposables.Add((IDisposable)task);
        disposables.Dispose();
        Assert.IsNotNull((object)task);
        Assert.AreEqual<TaskStatus>(TaskStatus.Faulted, ((Task)task).Status);
        Assert.AreEqual<bool>(false, ((Task)task).IsCanceled);
        Assert.IsNull(((Task)task).AsyncState);
        Assert.AreEqual<bool>(true, ((Task)task).IsFaulted);
        Assert.IsNotNull((object)cartViewModel);
        Assert.IsNotNull(cartViewModel.CartList);
      }
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
public void StartZXing878()
{
    using (PexTraceListenerContext.Create())
    {
      using (PexDisposableContext disposables = PexDisposableContext.Create())
      {
        CartServices cartServices;
        CartViewModel cartViewModel;
        Task<string> task;
        cartServices = new CartServices();
        ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
        ((Element)cartServices).AutomationId = (string)null;
        ((Element)cartServices).StyleId = (string)null;
        ((Element)cartServices).Parent = (Element)null;
        ((VisualElement)cartServices).BatchBegin();
        cartViewModel = new CartViewModel(cartServices);
        cartViewModel.GetGTIN("17", (string)null);
        task = this.StartZXing(cartViewModel, (object)null, (EventArgs)null);
        disposables.Add((IDisposable)task);
        disposables.Dispose();
        Assert.IsNotNull((object)task);
        Assert.AreEqual<TaskStatus>(TaskStatus.Faulted, ((Task)task).Status);
        Assert.AreEqual<bool>(false, ((Task)task).IsCanceled);
        Assert.IsNull(((Task)task).AsyncState);
        Assert.AreEqual<bool>(true, ((Task)task).IsFaulted);
        Assert.IsNotNull((object)cartViewModel);
        Assert.IsNotNull(cartViewModel.CartList);
      }
    }
}

[TestMethod]
[PexGeneratedBy(typeof(CartViewModelTest))]
public void StartZXing561()
{
    using (PexTraceListenerContext.Create())
    {
      using (PexDisposableContext disposables = PexDisposableContext.Create())
      {
        ResourceDictionary resourceDictionary;
        CartServices cartServices;
        CartViewModel cartViewModel;
        Task<string> task;
        resourceDictionary = new ResourceDictionary();
        cartServices = new CartServices();
        ((VisualElement)cartServices).Resources = resourceDictionary;
        ((Element)cartServices).AutomationId = (string)null;
        ((Element)cartServices).StyleId = (string)null;
        ((Element)cartServices).Parent = (Element)null;
        ((VisualElement)cartServices).BatchBegin();
        cartViewModel = new CartViewModel(cartServices);
        cartViewModel.GetGTIN("", (string)null);
        task = this.StartZXing(cartViewModel, (object)null, (EventArgs)null);
        disposables.Add((IDisposable)task);
        disposables.Dispose();
        Assert.IsNotNull((object)task);
        Assert.AreEqual<TaskStatus>(TaskStatus.Faulted, ((Task)task).Status);
        Assert.AreEqual<bool>(false, ((Task)task).IsCanceled);
        Assert.IsNull(((Task)task).AsyncState);
        Assert.AreEqual<bool>(true, ((Task)task).IsFaulted);
        Assert.IsNotNull((object)cartViewModel);
        Assert.IsNotNull(cartViewModel.CartList);
      }
    }
}
    }
}
