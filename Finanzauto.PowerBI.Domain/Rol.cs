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
    public class Rol : Entity
    {
        public int rolId { get; set; }
        public string rolDescription { get; set; }

        public List<User> GetUsers { get; set; }
    }
}
