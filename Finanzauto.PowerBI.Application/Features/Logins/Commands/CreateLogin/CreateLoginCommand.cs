using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logins.Commands.CreateLogin
{
    public class CreateLoginCommand : IRequest<ResponseLoginVm>
    {
        public string lgnIp { get; set; }
        public int lgnConnectionTimes { get; set; }

        [JsonIgnore]
        public DateTime lgnLastConnection { get; set; } = DateTime.Now;
        
        public int usrId { get; set; }

        [JsonIgnore]
        public bool state { get; set; } = true;
        [JsonIgnore]
        public DateTime createDate { get; set; } = DateTime.Now;
        
        public int createUser { get; set; }
    }
}
