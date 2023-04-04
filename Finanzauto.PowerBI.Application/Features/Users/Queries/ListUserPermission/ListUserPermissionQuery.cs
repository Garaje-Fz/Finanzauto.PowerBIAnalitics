using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListUserPermission
{
    public class ListUserPermissionQuery : IRequest<List<ResponseMenuVm>>
    {
        public ListUserPermissionQuery(int? usrId)
        {
            UsrId = usrId;
        }
        public int? UsrId { get; set; }

    }
}
