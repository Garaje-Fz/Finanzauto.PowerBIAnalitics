using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.ChildReports.Commands.UpdateChildReport
{
    public class UpdateChildReportCommand : IRequest<ResponseChildReportVm>
    {
        public int chiId { get; set; }
        public int parId { get; set; }
        public string chiDescripcion { get; set; }
        public string chiUrl { get; set; }
        public bool state { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
