using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Permissions.Queries.ListPermission
{
    public class ListPermissionQuery : IRequest<ResponseListPermissionVm>
    {
        public ListPermissionQuery(int? perId)
        {
            PerId = perId;
        }
        public int? PerId { get; set; }
    }
}
