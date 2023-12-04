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
                var createPermisions = new Permission()
                {
                    usrId = request.usrId,
                    chilId = request.chId,
                    state = true,
                    createDate = DateTime.Now,
                    createUser = request.createUser,
                    modifyUser = request.createUser
                };
                var userEntityAdd = await _unitOfWork.Repository<Permission>().AddAsync(createPermisions);
                var permisionsChild = await _unitOfWork.Repository<ChildReport>().GetFirstOrDefaultAsync(x => x.chId == request.chId);
                var vmChildPermisions = new PermissionVm()
                {
                    usrId = request.usrId,
                    chId = request.chId,
                    parId = permisionsChild.parId
                };

                ResponsePermissionVm response = new ResponsePermissionVm()
                {
                    result = vmChildPermisions
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
