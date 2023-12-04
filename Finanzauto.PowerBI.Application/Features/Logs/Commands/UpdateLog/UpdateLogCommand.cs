using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logs.Commands.UpdateLog
{
    public class UpdateLogCommand : IRequest<ResponseLogVm>
    {
        public int logId { get; set; }
        public int usrId { get; set; }
        public int chiIld { get; set; }
        public int logPrintTimes { get; set; }

        [JsonIgnore]
        public DateTime logLastConnection { get; set; } = DateTime.Now;

        public bool state { get; set; }

        [JsonIgnore] 
        public DateTime modifyDate { get; set; } = DateTime.Now;                                               
        
        public int modifyUser { get; set; }
    }
}
