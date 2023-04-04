using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Auth.Models
{
    public class Refresh
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public Refresh(string token, string refreshtoken)
        {
            Token = token;
            RefreshToken = refreshtoken;
        }
    }
}
