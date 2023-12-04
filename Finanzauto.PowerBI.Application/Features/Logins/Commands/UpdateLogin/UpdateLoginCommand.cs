using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logins.Commands.UpdateLogin
{
    public class UpdateLoginCommand : IRequest<ResponseLoginVm>
    {
        public int lgnId { get; set; }
        public string lgnIp { get; set; }
        public int lgnConnectionTimes { get; set; } 

        [JsonIgnore]
        public DateTime lgnLastConnection { get; set; } = DateTime.Now;

        public int usrId { get; set; }
        public bool state { get; set; }

        [JsonIgnore]
        public DateTime modifyDate { get; set; } = DateTime.Now;

        public int modifyUser { get; set; }
    }
}
