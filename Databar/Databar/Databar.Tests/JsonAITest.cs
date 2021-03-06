// <copyright file="JsonAITest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Models.Tests
{
    [TestClass]
    [PexClass(typeof(JsonAI))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class JsonAITest
    {

        [PexMethod]
        public JsonAI Constructor()
        {
            JsonAI target = new JsonAI();
            return target;
            // TODO: add assertions to method JsonAITest.Constructor()
        }
    }
}
