﻿using Finanzauto.PowerBI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
         

namespace Finanzauto.PowerBI.Domain
{
    public class Permission : Entity
    {
        public int perId { get; set; }

        public int usrId { get; set; }
        [ForeignKey("usrId")]
        public User User { get; set; }

        public int chilId { get; set; }
        [ForeignKey("chilId")]
        public ChildReport ChildReport { get; set; }

    }
}
