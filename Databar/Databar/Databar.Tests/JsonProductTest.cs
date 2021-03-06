// <copyright file="JsonProductTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Models.Tests
{
    [TestClass]
    [PexClass(typeof(JsonProduct))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class JsonProductTest
    {

        [PexMethod]
        public JsonProduct Constructor()
        {
            JsonProduct target = new JsonProduct();
            return target;
            // TODO: add assertions to method JsonProductTest.Constructor()
        }
    }
}
