using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommand : IRequest<int>
    {
        public DeletePermissionCommand(int perId)
        {
            PerId = perId;
        }
        public int PerId { get; set; }
    }
}
