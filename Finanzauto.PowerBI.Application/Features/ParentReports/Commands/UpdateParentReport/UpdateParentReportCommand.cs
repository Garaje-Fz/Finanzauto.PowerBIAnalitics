using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.ParentReports.Commands.UpdateParentReport
{
    public class UpdateParentReportCommand : IRequest<ResponseParentReportVm>
    {
        public int parId { get; set; }
        public string parIcon { get; set; }
        public string parDescription { get; set; }
        public bool state { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
