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
            var command = new Permission();
            var updatePermission = await _unitOfWork.Repository<Permission>().GetFirstOrDefaultAsync(x => x.usrId == request.usrId && x.chilId == request.chId);
            if (updatePermission != null)
            {
                updatePermission.usrId = request.usrId;
                updatePermission.chilId = request.chId;
                updatePermission.state = request.state;
                updatePermission.modifyDate = DateTime.Now;
                updatePermission.modifyUser = request.modifyUser;
                command = await _unitOfWork.Repository<Permission>().UpdateAsync(updatePermission);
            }
            else
            {
                var createPermissions = new Permission()
                {
                    usrId = request.usrId,
                    chilId = request.chId,
                    state = request.state,
                    createDate = DateTime.Now,
                    createUser = request.modifyUser
                };
                command = await _unitOfWork.Repository<Permission>().AddAsync(createPermissions);
            }
            var parentReport = await _unitOfWork.Repository<ChildReport>().GetFirstOrDefaultAsync(x => x.chId == request.chId);
            var response = new PermissionVm()
            {
                usrId = command.usrId,
                chId = command.chilId,
                parId = parentReport.parId,
                state = command.state
            };
            return new ResponsePermissionVm()
            {
                result = response
            };
        }
    }
}
