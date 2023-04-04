using Finanzauto.PowerBI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Domain
{
    public class User : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int usrId { get; set; }
        public string usrName { get; set; }
        public string usrLastName { get; set; }
        public string usrEmail { get; set; }
        public string usrDomainName { get; set; }
        public int rolId { get; set; }
        [ForeignKey("rolId")]
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }

    }
}
