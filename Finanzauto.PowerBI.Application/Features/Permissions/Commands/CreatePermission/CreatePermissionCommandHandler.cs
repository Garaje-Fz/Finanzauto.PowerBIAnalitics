using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
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

namespace Finanzauto.PowerBI.Application.Features.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ResponsePermissionVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePermissionCommandHandler> _logger;


        public CreatePermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreatePermissionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponsePermissionVm> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var userEntity = _mapper.Map<Permission>(request);
                var userEntityAdd = await _unitOfWork.Repository<Permission>().AddAsync(userEntity);
                var userEntityResponse = _mapper.Map<PermissionVm>(userEntityAdd);

                ResponsePermissionVm response = new ResponsePermissionVm()
                {
                    result = userEntityResponse

                };

                _logger.LogInformation($"El permiso fue creado con el id {userEntityAdd.usrId}");


                return response;

            }
            else
            {
                throw new BadRequestException($"El permiso con Id {request.usrId} no fue creado");
            }

        }

    }
}
