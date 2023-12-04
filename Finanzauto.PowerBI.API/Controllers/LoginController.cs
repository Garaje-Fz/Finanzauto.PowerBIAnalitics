using Finanzauto.PowerBI.Application.Features.Logins.Commands.CreateLogin;
using Finanzauto.PowerBI.Application.Features.Logins.Commands.UpdateLogin;
using Finanzauto.PowerBI.Application.Features.Logins.Queries.ListLogin;
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
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetLogin")]
        public async Task<ActionResult<IEnumerable<Login>>> GetUser(int? lgnId)
        {
            var query = await _mediator.Send(new ListLoginQuery(lgnId));
            return Ok(query);
        }
        [HttpPost("AddLogin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseLoginVm>> CreateUser([FromBody] CreateLoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpLogin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseLoginVm>> UpdateUser([FromBody] UpdateLoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
