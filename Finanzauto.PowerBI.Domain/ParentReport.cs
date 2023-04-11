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
    public class ParentReport : Entity
    {
        public int parId { get; set; }
        public string parIcon { get; set; }
        public string parDescription { get; set; }

        public List<ChildReport> GetChildReports { get; set; }

    }
}
