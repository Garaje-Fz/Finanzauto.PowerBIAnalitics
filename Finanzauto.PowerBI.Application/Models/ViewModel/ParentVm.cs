using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class ParentVm
    {
        public int parId { get; set; }
        public string parDescription { get; set; }
        public string parIcon { get; set; }
        public List<ChildVm> items { get; set; }
    }
}
