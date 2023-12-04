using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResponseUserVm>
    {
        public int usrId { get; set; }
        public string? usrName { get; set; }
        public string? usrLastName { get; set; }
        public string? usrEmail { get; set; }
        public string? usrDomainName { get; set; }
        public int rolId { get; set; } = 0;
        public bool? state { get; set; }

        [JsonIgnore]
        public DateTime modifyDate { get; set; } = DateTime.Now;

        public int modifyUser { get; set; }
    }
}
