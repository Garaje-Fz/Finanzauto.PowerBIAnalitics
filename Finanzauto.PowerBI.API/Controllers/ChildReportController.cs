using Finanzauto.PowerBI.Application.Features.ChildReports.Commands.CreateChildReport;
using Finanzauto.PowerBI.Application.Features.ChildReports.Commands.UpdateChildReport;
using Finanzauto.PowerBI.Application.Features.ChildReports.Querys.ListChildReport;
using Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser;
using Finanzauto.PowerBI.Application.Features.Users.Commands.UpdateUser;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Finanzauto.PowerBI.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [EnableCors]
#if !DEBUG
        [Authorize]
#endif
    public class ChildReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChildReportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetChildReport")]
        public async Task<ActionResult<IEnumerable<ChildReportVm>>> GetUser(int? chId)
        {
            var query = await _mediator.Send(new ListChildReportQuery(chId));
            return Ok(query);
        }
        [HttpPost("AddChildReport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseChildReportVm>> CreateUser([FromBody] CreateChildReportCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpChildReport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseChildReportVm>> UpdateUser([FromBody] UpdateChildReportCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
