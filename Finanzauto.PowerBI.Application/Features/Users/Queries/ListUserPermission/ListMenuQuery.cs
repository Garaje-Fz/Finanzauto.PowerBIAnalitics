using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListUserPermission
{
    public class ListMenuQuery : IRequest<GetUserMenuVm>
    {
        public ListMenuQuery(int? usrId)
        {
            UsrId = usrId;
        }
        public int? UsrId { get; set; }
    }
}
