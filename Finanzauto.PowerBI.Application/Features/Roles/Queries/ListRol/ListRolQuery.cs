using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Roles.Queries.ListRol
{
    public class ListRolQuery : IRequest<ResponseListRolVm>
    {
        public ListRolQuery(int? rolId)
        {
            RolId = rolId;
        }
        public int? RolId { get; set; }
    }
}
