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
        // {0}, {1} and {2} are replaced in RestService methods with string.Format
        //public static string RestUrl = "http://138.68.180.198:8080/restsql/res/databar_db.{0}/{1}{2}";
        public static string RestUrl = "https://188.226.133.140:8443/restsql/res/databar_db.{0}/{1}{2}";
        
        

        // Append to resturl {2} to get JSON-output
        public static string JSONoutput = "?_output=application/json";

        // Credentials for default tomcat user "readonly", which has readonly-access to the restSQL API.
        public static string Username = "all";
        public static string Password = "all";

        // Admin
        public static string Admin = "admin";
        public static string AdminAuthUrl = "https://188.226.133.140:8443/restsql/conf/security";
    }
}
