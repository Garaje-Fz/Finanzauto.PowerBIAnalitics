﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class ListRolVm
    {
        public int rolId { get; set; }
        public string rolDescription { get; set; }
        public bool state { get; set; }
        public DateTime createDate { get; set; }
        public int createUser { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
