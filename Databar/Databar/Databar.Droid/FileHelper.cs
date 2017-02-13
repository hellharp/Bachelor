using System;
using System.IO;
using Xamarin.Forms;
using Databar.Droid;
using Databar;
using SQLite.Net.Async;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(FileHelper))]
namespace Databar.Droid
{
    public class FileHelper : IFileHelper
    {
        //public string GetLocalFilePath(string filename)
        //{
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    return Path.Combine(path, filename);
        //}


        //https://xamarindevelopervietnam.wordpress.com/2016/01/08/how-to-use-sqliteasync-pcl-in-xamarin-forms/
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            const string sqliteFilename = "DatabarDB.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(
            platform,
            new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}