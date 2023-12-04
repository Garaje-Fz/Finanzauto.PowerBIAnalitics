using Finanzauto.PowerBI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class PermissionVm
    {
        public int usrId { get; set; }
        public int chId { get; set; }
        public bool? state { get; set; }
        public int parId { get; set; }
    }
}
