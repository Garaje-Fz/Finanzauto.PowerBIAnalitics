using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Models.ViewModel.MenuListChildVm
{
    public class GetListAllChildByUserVm
    {
        public int? usrId { get; set; }
        public bool data { get; set; }
        public List<ListParentChildVm> menu { get; set; }
    }
}
