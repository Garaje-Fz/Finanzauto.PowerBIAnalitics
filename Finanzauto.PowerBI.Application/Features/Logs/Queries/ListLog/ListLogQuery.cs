using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logs.Queries.ListLog
{
    public class ListLogQuery : IRequest<ResponseListLogVm>
    {
        public ListLogQuery(int? logId)
        {
            LogId = logId;
        }
        public int? LogId { get; set; }
    }
}
