using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xamarin.Forms;
using Databar.Services;
// <copyright file="CartServicesTest.Sum.g.cs">Copyright ©  2014</copyright>
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
[PexRaisedException(typeof(NullReferenceException))]
public void SumThrowsNullReferenceException636()
{
    CartServices cartServices;
    decimal d;
    cartServices = new CartServices();
    ((VisualElement)cartServices).Resources = (ResourceDictionary)null;
    ((Element)cartServices).AutomationId = (string)null;
    ((Element)cartServices).StyleId = (string)null;
    ((Element)cartServices).Parent = (Element)null;
    ((VisualElement)cartServices).BatchCommit();
    d = this.Sum(cartServices, (List<string>)null);
}

[TestMethod]
[PexGeneratedBy(typeof(CartServicesTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void SumThrowsNullReferenceException63601()
{
    ResourceDictionary resourceDictionary;
    CartServices cartServices;
    decimal d;
    resourceDictionary = new ResourceDictionary();
    cartServices = new CartServices();
    ((VisualElement)cartServices).Resources = resourceDictionary;
    ((Element)cartServices).AutomationId = (string)null;
    ((Element)cartServices).StyleId = (string)null;
    ((Element)cartServices).Parent = (Element)null;
    ((VisualElement)cartServices).BatchCommit();
    d = this.Sum(cartServices, (List<string>)null);
}
    }
}
