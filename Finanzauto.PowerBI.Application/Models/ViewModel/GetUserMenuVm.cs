using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel
{
    public class GetUserMenuVm
    {
        public int usrId { get; set; }
        public Boolean data { get; set; }
        public List<ParentVm> menu { get; set; }
    }
}
