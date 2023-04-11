using Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser;
using Finanzauto.PowerBI.Application.Features.Users.Commands.UpdateUser;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUserPermission;
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
#if !DEBUG
        [Authorize]
#endif  
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(string? usrDomainName, int? usrId)
        {
            var query = await _mediator.Send(new ListUserQuery(usrDomainName, usrId));
            return Ok(query);
        }

        [HttpGet("GetUserMenuPermission")]
        public async Task<ActionResult<IEnumerable<GetUserMenuVm>>> GetMenuUser(int? usrId)
        {
            var query = await _mediator.Send(new ListMenuQuery(usrId));

            if (query.data == false)
            {
                return BadRequest("No hay Reportes asociados a este usuario");
            }

            return Ok(query);
        }
        [HttpPost("AddUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseUserVm>> CreateUser([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseUserVm>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
