using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.ChildReports.Commands.UpdateChildReport
{
    public class UpdateChildReportCommand : IRequest<ResponseChildReportVm>
    {
        public int ChId { get; set; }
        public int ParId { get; set; } = 0;
        public string? ChiDescripcion { get; set; }
        public string? ChiUrl { get; set; }
        public bool? State { get; set; }
        public int ModifyUser { get; set; }
    }
}
