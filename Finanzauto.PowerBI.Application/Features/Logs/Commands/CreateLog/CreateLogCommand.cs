using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logs.Commands.CreateLog
{
    public class CreateLogCommand : IRequest<ResponseLogVm>
    {
        public int usrId { get; set; }
        public int chId { get; set; }
        public int logPrintTimes { get; set; }

        [JsonIgnore]
        public DateTime logLastConnection { get; set; } = DateTime.Now;

        [JsonIgnore]
        public bool state { get; set; } = true;
        [JsonIgnore]
        public DateTime createDate { get; set; } = DateTime.Now;

        public int createUser { get; set; }
    }
}
