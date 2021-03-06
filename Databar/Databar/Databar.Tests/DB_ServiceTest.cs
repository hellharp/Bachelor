// <copyright file="DB_ServiceTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Services.Tests
{
    [TestClass]
    [PexClass(typeof(DB_Service))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DB_ServiceTest
    {

        [PexMethod]
        public IDB_Service InstanceGet()
        {
            IDB_Service result = DB_Service.Instance;
            return result;
            // TODO: add assertions to method DB_ServiceTest.InstanceGet()
        }
    }
}
