using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar
{
    public static class Constants
    {
        //http://www.example.com/api/resource/tablename/?param1=info1
        // restSQL: /restsql/res/{resName}/{resId}
        // /restsql/res/film/1023
        // /restsql/res/film?year=2010

        // URL of REST service
        public static string RestUrl = "http://www.example.com/api/resource/";
        // Credentials that are hard coded into the REST service
        public static string Username = "admin";
        public static string Password = "noH4x";
    }
}
