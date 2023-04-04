using Finanzauto.PowerBI.Application.Features.Logs.Commands.CreateLog;
using Finanzauto.PowerBI.Application.Features.Logs.Commands.UpdateLog;
using Finanzauto.PowerBI.Application.Features.Logs.Queries.ListLog;
using Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser;
using Finanzauto.PowerBI.Application.Features.Users.Commands.UpdateUser;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Finanzauto.PowerBI.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Authorize]
    public class LogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetLog")]
        public async Task<ActionResult<IEnumerable<Log>>> GetUser(int? logId)
        {
            var query = await _mediator.Send(new ListLogQuery(logId));
            return Ok(query);
        }
        [HttpPost("AddLog")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseLogVm>> CreateUser([FromBody] CreateLogCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpLog")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseLogVm>> UpdateUser([FromBody] UpdateLogCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
