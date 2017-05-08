using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Databar.Models;
using Xamarin.Forms;
using Databar.Services;
// <copyright file="CartServicesTest.RemoveProduct.g.cs">Copyright ©  2014</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Databar.Services.Tests
{
    public partial class CartServicesTest
    {

[TestMethod]
[PexGeneratedBy(typeof(CartServicesTest))]
public void RemoveProduct387()
{
    CartServices cartServices;
    cartServices = new CartServices();
    ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
    ((Element)cartServices).AutomationId = (string)null;
    ((Element)cartServices).StyleId = (string)null;
    ((Element)cartServices).Parent = (Element)null;
    ((VisualElement)cartServices).BatchCommit();
    this.RemoveProduct(cartServices, (Product)null);
    Assert.IsNotNull((object)cartServices);
    Assert.IsNotNull(((Page)cartServices).ToolbarItems);
    Assert.IsNull(((VisualElement)cartServices).Resources);
    Assert.AreEqual<string>((string)null, ((Element)cartServices).AutomationId);
    Assert.AreEqual<string>((string)null, ((Element)cartServices).StyleId);
}

[TestMethod]
[PexGeneratedBy(typeof(CartServicesTest))]
public void RemoveProduct38701()
{
    ResourceDictionary resourceDictionary;
    CartServices cartServices;
    resourceDictionary = new ResourceDictionary();
    cartServices = new CartServices();
    ((VisualElement)cartServices).Resources = resourceDictionary;
    ((Element)cartServices).AutomationId = (string)null;
    ((Element)cartServices).StyleId = (string)null;
    ((Element)cartServices).Parent = (Element)null;
    ((VisualElement)cartServices).BatchCommit();
    this.RemoveProduct(cartServices, (Product)null);
    Assert.IsNotNull((object)cartServices);
    Assert.IsNotNull(((Page)cartServices).ToolbarItems);
    Assert.IsNotNull(((VisualElement)cartServices).Resources);
    Assert.IsNull(((VisualElement)cartServices).Resources.MergedWith);
    Assert.AreEqual<string>((string)null, ((Element)cartServices).AutomationId);
    Assert.AreEqual<string>((string)null, ((Element)cartServices).StyleId);
}
    }
}
