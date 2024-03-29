﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class ListLogVm
    {
        public int logId { get; set; }
        public int usrId { get; set; }
        public int chiIld { get; set; }
        public string logPrintTimes { get; set; }
        public string logLastConnection { get; set; }
        public bool state { get; set; }
        public DateTime createDate { get; set; }
        public int createUser { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
