using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.ChildReports.Commands.CreateChildReport
{
    public class CreateChildReportCommand : IRequest<ResponseChildReportVm>
    {
        public int parId { get; set; }
        public string chiDescription { get; set; }
        public string chiUrl { get; set; }
        public bool state { get; set; }
        public DateTime createDate { get; set; }
        public int createUser { get; set; }
    }
}
