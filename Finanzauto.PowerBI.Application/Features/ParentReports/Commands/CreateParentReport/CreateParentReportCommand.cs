using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.ParentReports.Commands.CreateParentReport
{
    public class CreateParentReportCommand : IRequest<ResponseParentReportVm>
    {
        public string parIcon { get; set; }
        public string parDescription { get; set; }
        public bool state { get; set; }
        public DateTime createDate { get; set; }
        public int createUser { get; set; }
    }
}
