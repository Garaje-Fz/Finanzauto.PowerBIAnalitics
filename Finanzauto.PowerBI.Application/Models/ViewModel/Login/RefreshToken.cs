using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel.Login
{
    public class RefreshToken
    {
        public string JwtId { get; set; }
        public string usrId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
