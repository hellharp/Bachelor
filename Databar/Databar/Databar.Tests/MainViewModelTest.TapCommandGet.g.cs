using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using Databar.ViewModels;
// <copyright file="MainViewModelTest.TapCommandGet.g.cs">Copyright ©  2014</copyright>
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
    public partial class MainViewModelTest
    {

[TestMethod]
[PexGeneratedBy(typeof(MainViewModelTest))]
public void TapCommandGet753()
{
    MainViewModel mainViewModel;
    ICommand iCommand;
    mainViewModel = new MainViewModel();
    iCommand = this.TapCommandGet(mainViewModel);
    Assert.IsNotNull((object)iCommand);
    Assert.IsNotNull((object)mainViewModel);
    Assert.IsNotNull(mainViewModel.TapCommand);
    Assert.IsTrue
        (object.ReferenceEquals(mainViewModel.TapCommand, (object)iCommand));
}
    }
}
