using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.CreatePermission;
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

namespace Finanzauto.PowerBI.Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, ResponsePermissionVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePermissionCommandHandler> _logger;


        public UpdatePermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdatePermissionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponsePermissionVm> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var updatePermission = await _unitOfWork.Repository<Permission>().GetFirstOrDefaultAsync(x => x.perId == request.perId && x.state == true);

            if (updatePermission == null)
            {
                updatePermission.usrId = request.usrId;
                updatePermission.chilId = request.chilId;
                updatePermission.state = request.state;
                updatePermission.modifyDate = DateTime.Now;
                updatePermission.modifyUser = request.usrId;
               
                var permissionEntityGetResponse = await _unitOfWork.Repository<Permission>().UpdateAsync(updatePermission);
                var permissionEntityResponse = _mapper.Map<PermissionVm>(permissionEntityGetResponse);

                ResponsePermissionVm response = new ResponsePermissionVm()
                {
                    result = permissionEntityResponse

                };

                _logger.LogInformation($"El permiso fue creado con el id {updatePermission.usrId}");


                return response;

            }
            else
            {
                throw new BadRequestException($"El usuario con Id {request.usrId} ya existe");
            }
        }
    }
}
