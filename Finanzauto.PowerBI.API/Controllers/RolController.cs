﻿using Finanzauto.PowerBI.Application.Features.Roles.Commands.CreateRol;
using Finanzauto.PowerBI.Application.Features.Roles.Commands.UpdateRol;
using Finanzauto.PowerBI.Application.Features.Roles.Queries.ListRol;
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
    public class RolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetRol")]
        public async Task<ActionResult<IEnumerable<User>>> GetRol(int? rolId)
        {
            var query = await _mediator.Send(new ListRolQuery(rolId));
            return Ok(query);
        }
        [HttpPost("AddRol")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseRolVm>> CreateRol([FromBody] CreateRolCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpRol")]
        public async Task<ActionResult<ResponseRolVm>> UpdateRol([FromBody] UpdateRolCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
