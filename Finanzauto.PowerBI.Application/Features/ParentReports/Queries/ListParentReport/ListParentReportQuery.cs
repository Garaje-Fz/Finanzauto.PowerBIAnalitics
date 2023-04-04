using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.ParentReports.Queries.ListParentReport
{
    public class ListParentReportQuery : IRequest<ResponseListParentReportVm>
    {
        public ListParentReportQuery(int? parId)
        {
            ParId = parId;
        }
        public int? ParId { get; set; }
    }
}
