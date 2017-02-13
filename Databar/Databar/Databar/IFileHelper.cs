using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar
{
    // Fra https://developer.xamarin.com/guides/xamarin-forms/working-with/databases/
    public interface IFileHelper
    {
        //string GetLocalFilePath(string filename);

        ////https://xamarindevelopervietnam.wordpress.com/2016/01/08/how-to-use-sqliteasync-pcl-in-xamarin-forms/
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
