// <copyright file="PayConfirmationViewModelTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.ViewModels;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.ViewModels.Tests
{
    [TestClass]
    [PexClass(typeof(PayConfirmationViewModel))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PayConfirmationViewModelTest
    {

        [PexMethod]
        public PayConfirmationViewModel Constructor()
        {
            PayConfirmationViewModel target = new PayConfirmationViewModel();
            return target;
            // TODO: add assertions to method PayConfirmationViewModelTest.Constructor()
        }
    }
}
