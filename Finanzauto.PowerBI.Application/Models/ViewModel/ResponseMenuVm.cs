using Finanzauto.PowerBI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class ResponseMenuVm
    {
        public int usrId { get; set; }
        public string usrName{ get; set; }
        public int rolId { get; set; }
        public List<PermissionMenuVm> PermissionMenu { get; set; }

    }
}
