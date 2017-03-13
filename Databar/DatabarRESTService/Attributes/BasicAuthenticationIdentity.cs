using System.Security.Principal;

namespace DatabarRESTService.Attributes
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public string Password { get; set; }

        public BasicAuthenticationIdentity(string username, string password)
            : base(username, "Basic")
        {
            this.Password = password;    
        }
    }
}
