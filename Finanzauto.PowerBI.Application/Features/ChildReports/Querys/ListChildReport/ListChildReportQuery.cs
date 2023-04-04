using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.ChildReports.Querys.ListChildReport
{
    public class ListChildReportQuery : IRequest<ResponseListChildReportVm>
    {
        public ListChildReportQuery(int? chId)
        {
            ChId = chId;
        }
        public int? ChId { get; set; }
    }
}
