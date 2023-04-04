using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class LogVm
    {
        public int logId { get; set; }
        public int usrId { get; set; }
        public int chiIld { get; set; }
        public int logPrintTimes { get; set; }
        public DateTime logLastConnection { get; set; }

    }
}
