using System.Windows.Input;
// <copyright file="MainViewModelTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.ViewModels;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.ViewModels.Tests
{
    [TestClass]
    [PexClass(typeof(MainViewModel))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MainViewModelTest
    {

        [PexMethod]
        public ICommand TapCommandGet([PexAssumeUnderTest]MainViewModel target)
        {
            ICommand result = target.TapCommand;
            return result;
            // TODO: add assertions to method MainViewModelTest.TapCommandGet(MainViewModel)
        }

        [PexMethod]
        public MainViewModel Constructor()
        {
            MainViewModel target = new MainViewModel();
            return target;
            // TODO: add assertions to method MainViewModelTest.Constructor()
        }
    }
}
