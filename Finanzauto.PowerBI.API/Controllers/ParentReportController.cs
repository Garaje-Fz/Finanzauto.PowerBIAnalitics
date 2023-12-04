using Finanzauto.PowerBI.Application.Features.ParentReports.Commands.CreateParentReport;
using Finanzauto.PowerBI.Application.Features.ParentReports.Commands.UpdateParentReport;
using Finanzauto.PowerBI.Application.Features.ParentReports.Queries.ListParentReport;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.CreatePermission;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.UpdatePermission;
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
#if !DEBUG
        [Authorize]
#endif
    public class ParentReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParentReportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetParentReport")]
        public async Task<ActionResult<IEnumerable<ParentReport>>> GetPermission(int? parid)
        {
            var query = await _mediator.Send(new ListParentReportQuery(parid));
            return Ok(query);
        }

        [HttpPost("AddParentReport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseParentReportVm>> CreatePermission([FromBody] CreateParentReportCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpParentReport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseParentReportVm>> UpdatePermission([FromBody] UpdateParentReportCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
