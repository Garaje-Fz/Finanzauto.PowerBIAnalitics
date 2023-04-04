﻿using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest<ResponsePermissionVm>
    {
        public int perId { get; set; }
        public int usrId { get; set; }
        public int chilId { get; set; }
        public bool state { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
