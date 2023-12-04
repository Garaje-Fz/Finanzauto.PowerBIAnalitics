using Finanzauto.PowerBI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class ListUserVm
    {
        public int usrId { get; set; }
        public string usrName { get; set; }
        public string usrLastName { get; set; }
        public string usrEmail { get; set; }
        public string usrDomainName { get; set; }
        public int rolId { get; set; }
        public bool state { get; set; }
        public DateTime createDate { get; set; }
        public DateTime? modifyDate { get; set; }
        public int createUser { get; set; }
        public int? modifyUser { get; set; }
    }
}
