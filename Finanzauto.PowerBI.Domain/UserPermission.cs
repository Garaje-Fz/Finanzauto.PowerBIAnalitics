using Finanzauto.PowerBI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Domain
{
    public class UserPermission : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uspId { get; set; }
        public int usrId { get; set; }
        [ForeignKey("usrId")]
        public virtual User User { get; set; }
        public int perId { get; set; }
        [ForeignKey("perId")]
        public virtual Permission Permission { get; set; }
        public int parId { get; set; }
        [ForeignKey("parId")]
        public virtual ParentReport ParentReport { get; set; }


    }
}
