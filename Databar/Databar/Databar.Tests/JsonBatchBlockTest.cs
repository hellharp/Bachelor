// <copyright file="JsonBatchBlockTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Models.Tests
{
    [TestClass]
    [PexClass(typeof(JsonBatchBlock))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class JsonBatchBlockTest
    {

        [PexMethod]
        public JsonBatchBlock Constructor()
        {
            JsonBatchBlock target = new JsonBatchBlock();
            return target;
            // TODO: add assertions to method JsonBatchBlockTest.Constructor()
        }
    }
}
