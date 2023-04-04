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
    public class Login : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int lgnId { get; set; }
        public string lgnIp { get; set; }
        public int lgnConnectionTimes { get; set; }
        public DateTime lgnLastConnection { get; set; }
        public int usrId { get; set; }
        [ForeignKey("usrId")]
        public User User { get; set; }

    }
}
