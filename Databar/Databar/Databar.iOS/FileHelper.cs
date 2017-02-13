using System;
using System.IO;
using Xamarin.Forms;
using Databar.iOS;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;
using SQLite.Net;

[assembly: Dependency(typeof(FileHelper))]
namespace Databar.iOS
{
    public class FileHelper : IFileHelper
    {
        //public string GetLocalFilePath(string filename)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

        //    if (!Directory.Exists(libFolder))
        //    {
        //        Directory.CreateDirectory(libFolder);
        //    }

        //    return Path.Combine(libFolder, filename);
        //}

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            const string sqliteFilename = "XamarinTemplate.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            var platform = new SQLitePlatformIOS();

            var connectionWithLock = new SQLiteConnectionWithLock(
            platform,
            new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}