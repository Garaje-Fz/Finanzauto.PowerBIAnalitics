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
    public class Log : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int logId { get; set; }
        public int logPrintTimes { get; set; }
        public DateTime logLastConnection { get; set; }
        public int usrId { get; set; }
        [ForeignKey("usrId")]
        public User User { get; set; }
        public int chId { get; set; }
        [ForeignKey("chId")]
        public ChildReport ChildReport { get; set; }

    }
}
