using Finanzauto.PowerBI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Domain
{
    public class ChildReport : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int chId { get; set; }
        public string chiDescription { get; set; }
        public string chiUrl { get; set; }
        public int parId { get; set; }
        [ForeignKey("parId")]
        public virtual ParentReport ParentReport { get; set; }
        public virtual Permission Permission { get; set; }

    }
}
