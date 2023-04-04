using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class LoginVm
    {
        public int lgnId { get; set; }
        public string lgnIp { get; set; }
        public int lgnConnectionTimes { get; set; }
        public DateTime lgnLastConnection { get; set; }
        public int usrId { get; set; }
    }
}
