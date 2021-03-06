using Microsoft.VisualStudio.TestTools.UnitTesting;
using Databar.Models;
using System.Threading.Tasks;
using Databar.Services;
using Microsoft.Pex.Framework.Generated;
// <copyright file="DBRestManagerTest.DeleteBatchBlockAsync.g.cs">Copyright ©  2014</copyright>
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
    public partial class DBRestManagerTest
    {

[TestMethod]
[PexGeneratedBy(typeof(DBRestManagerTest))]
public void DeleteBatchBlockAsync749()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      RestService restService;
      DBRestManager dBRestManager;
      Task task;
      restService = new RestService();
      dBRestManager = new DBRestManager((IRestService)restService);
      BatchBlock s0 = new BatchBlock();
      s0.BatchNr = "";
      s0.Blocked = false;
      task = this.DeleteBatchBlockAsync(dBRestManager, s0);
      disposables.Add((IDisposable)task);
      disposables.Dispose();
      Assert.IsNotNull((object)task);
      Assert.AreEqual<TaskStatus>(TaskStatus.WaitingForActivation, task.Status);
      Assert.AreEqual<bool>(false, task.IsCanceled);
      Assert.IsNull(task.AsyncState);
      Assert.AreEqual<bool>(false, task.IsFaulted);
      Assert.IsNotNull((object)dBRestManager);
    }
}

[TestMethod]
[PexGeneratedBy(typeof(DBRestManagerTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void DeleteBatchBlockAsyncThrowsNullReferenceException197()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      DBRestManager dBRestManager;
      Task task;
      dBRestManager = new DBRestManager((IRestService)null);
      task = this.DeleteBatchBlockAsync(dBRestManager, (BatchBlock)null);
      disposables.Add((IDisposable)task);
      disposables.Dispose();
    }
}

[TestMethod]
[PexGeneratedBy(typeof(DBRestManagerTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void DeleteBatchBlockAsyncThrowsNullReferenceException528()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      DBRestManager dBRestManager;
      Task task;
      dBRestManager = new DBRestManager((IRestService)null);
      BatchBlock s0 = new BatchBlock();
      s0.BatchNr = (string)null;
      s0.Blocked = false;
      task = this.DeleteBatchBlockAsync(dBRestManager, s0);
      disposables.Add((IDisposable)task);
      disposables.Dispose();
    }
}

[TestMethod]
[PexGeneratedBy(typeof(DBRestManagerTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void DeleteBatchBlockAsyncThrowsNullReferenceException684()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      DBRestManager dBRestManager;
      Task task;
      dBRestManager = new DBRestManager((IRestService)null);
      BatchBlock s0 = new BatchBlock();
      s0.BatchNr = "";
      s0.Blocked = false;
      task = this.DeleteBatchBlockAsync(dBRestManager, s0);
      disposables.Add((IDisposable)task);
      disposables.Dispose();
    }
}
    }
}
