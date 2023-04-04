using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Roles.Commands.UpdateRol
{
    public class UpdateRolCommand : IRequest<ResponseRolVm>
    {
        public int rolId { get; set; }
        public string rolDescription { get; set; }
        public bool state { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
