using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar
{
    /// <summary>
    /// Constants class to keep track of constants used in the application.
    /// </summary>
    public static class Constants
    {

        /// <summary>
        /// URL of restSQL resource.
        /// {0}, {1} and {2} are replaced in RestService methods with string.Format.
        /// </summary>
        public static string RestUrl = "https://67.205.184.148:8443/restsql/res/databar_db.{0}/{1}{2}";
        
        /// <summary>
        /// Append to resturl {2] to get JSON-output.
        /// </summary>
        public static string JSONoutput = "?_output=application/json";

        // Credentials for default tomcat user "readonly", which has readonly-access to the restSQL API.
        /// <summary>
        /// Default username
        /// </summary>
        public static string Username = "all";
        /// <summary>
        /// Default password
        /// </summary>
        public static string Password = "all";

        /// <summary>
        /// Default administrator username to suggest on LoginModal.
        /// </summary>
        public static string Admin = "admin";
        /// <summary>
        /// URL of admin authentication.
        /// </summary>
        public static string AdminAuthUrl = "https://67.205.184.148:8443/restsql/conf/security";
    }
}
