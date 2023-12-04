using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Features.ChildReports.Commands.CreateChildReport;
using Finanzauto.PowerBI.Application.Features.ChildReports.Commands.UpdateChildReport;
using Finanzauto.PowerBI.Application.Features.ChildReports.Querys.ListChildReport;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Application.Models.ViewModel.Login;
using Finanzauto.PowerBI.Auth.Models;
using Finanzauto.PowerBI.Auth.Services;
using Finanzauto.PowerBI.Domain;
using Finanzauto.PowerBI.Infraestructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Finanzauto.PowerBI.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PowerBIDbContext _context;


        public AuthController(
            ILogger<AuthController> logger,
            IConfiguration configuration,
            IMediator mediator,
            PowerBIDbContext context)  
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("Login")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> Login([FromBody] UserLogon user)
        {
            LoginAuth login = new LoginAuth(_configuration, _unitOfWork, _mediator, _context);
            var generate = login.Login(user.UserName, user.Password);
            if (!generate.Result.Item1.CodigoMensaje.Equals(0))
            {
                return BadRequest(generate.Result.Item1.DescMensaje);
            }
            return Ok(generate.Result.Item1);
        }

        [HttpPost("RefreshToken")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> Refresh([FromBody] Refresh request)
        {
            LoginAuth login = new LoginAuth(_configuration, _unitOfWork, _mediator, _context);
            var refresh = login.RefreshToken(request.Token, request.RefreshToken);
            return Ok(refresh.Result);
        }
    }
}
