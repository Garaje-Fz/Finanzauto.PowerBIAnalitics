using Finanzauto.PowerBI.Application.Features.Permissions.Commands.CreatePermission;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.DeletePermission;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.UpdatePermission;
using Finanzauto.PowerBI.Application.Features.Permissions.Queries.ListPermission;
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
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetPermission")]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermission(int? usrId)
        {
            var query = await _mediator.Send(new ListPermissionQuery(usrId));
            return Ok(query);
        }
        //[HttpPost("AddPermission")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //public async Task<ActionResult<ResponsePermissionVm>> CreatePermission([FromBody] CreatePermissionCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}

        [HttpPut("AddPermission")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsePermissionVm>> UpdatePermission([FromBody] UpdatePermissionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        //[HttpDelete("DelPermission")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //public async Task<ActionResult<int>> DeletePermission([FromBody] DeletePermissionCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}
