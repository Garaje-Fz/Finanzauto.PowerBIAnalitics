using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Roles.Commands.CreateRol
{
    public class CreateRolCommand : IRequest<ResponseRolVm>
    {
        public string rolDescription { get; set; }

        [JsonIgnore]
        public bool state { get; set; } = true;

    }
}
