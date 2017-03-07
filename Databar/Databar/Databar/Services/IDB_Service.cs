using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Services
{
    //https://xamarindevelopervietnam.wordpress.com/2016/01/08/how-to-use-sqliteasync-pcl-in-xamarin-forms/
    public interface IDB_Service
    {
        void CreateDbIfNotExist();
    }
}
