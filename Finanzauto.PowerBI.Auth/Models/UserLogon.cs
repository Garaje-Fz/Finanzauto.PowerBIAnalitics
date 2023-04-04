using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Auth.Models
{
    public class UserLogon
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserLogon(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
