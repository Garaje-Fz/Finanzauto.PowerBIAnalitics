using Finanzauto.PowerBI.Application.Models.ViewModel.MenuListChildVm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListAllChildByUser
{
    public class ListAllChildByUserQuery : IRequest<GetListAllChildByUserVm>
    {
        public ListAllChildByUserQuery(int? usrId)
        {
            UsrId = usrId;
        }
        public int? UsrId { get; set; }
    }
}
