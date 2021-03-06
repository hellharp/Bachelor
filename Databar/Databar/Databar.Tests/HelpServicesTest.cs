using System.Collections.ObjectModel;
using Databar.Models;
// <copyright file="HelpServicesTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Services.Tests
{
    [TestClass]
    [PexClass(typeof(HelpServices))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class HelpServicesTest
    {

        [PexMethod]
        public ObservableCollection<HelpItem> getHelpList([PexAssumeUnderTest]HelpServices target, string page)
        {
            ObservableCollection<HelpItem> result = target.getHelpList(page);
            return result;
            // TODO: add assertions to method HelpServicesTest.getHelpList(HelpServices, String)
        }
    }
}
