using Finanzauto.PowerBI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Domain
{
    public class Tokens : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tknId { get; set; }

        public int usrId { get; set; }
        [ForeignKey("usrId")]
        [JsonIgnore]
        public User User { get; set; }

        public string tknToken { get; set; }
        public string tknRefreshToken { get; set; }
        public bool tknIsUsed { get; set; }
        public string JwtId { get; set; }
        public DateTime ExpirateDate { get; set; }
        public int CodigoMensaje { get; set; }
        public string DescMensaje { get; set; }
    }
}
