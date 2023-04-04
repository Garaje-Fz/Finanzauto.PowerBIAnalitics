using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
using Finanzauto.PowerBI.Application.Features.Logins.Commands.CreateLogin;
using Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Roles.Commands.CreateRol
{
    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, ResponseRolVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRolCommandHandler> _logger;

        public CreateRolCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateRolCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseRolVm> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            var VerifiUser = await _unitOfWork.Repository<Rol>().GetFirstOrDefaultAsync(x => x.rolDescription == request.rolDescription && x.state == true);

            if (VerifiUser == null)
            {
                var rolEntity = _mapper.Map<Rol>(request);
                var rolEntityAdd = await _unitOfWork.Repository<Rol>().AddAsync(rolEntity);
                var rolEntityResponse = _mapper.Map<RolVm>(rolEntityAdd);

                ResponseRolVm responseUser = new ResponseRolVm()
                {
                    result = rolEntityResponse

                };

                _logger.LogInformation($"El rol fue creado con el id {rolEntityResponse.rolId}");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El rol {request.rolDescription} ya existe");
            }

        }
    }
}
