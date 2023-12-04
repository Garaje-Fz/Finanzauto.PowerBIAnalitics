using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommand : IRequest<ResponsePermissionVm>
    {
        public int usrId { get; set; }
        public int chId { get; set; }
        public int createUser { get; set; }
    }
}
