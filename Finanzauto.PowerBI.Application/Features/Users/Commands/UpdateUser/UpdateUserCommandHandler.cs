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

namespace Finanzauto.PowerBI.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseUserVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseUserVm> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUser = await _unitOfWork.Repository<User>().GetFirstOrDefaultAsync(x => x.usrId == request.usrId);

            if (updateUser != null)
            {
                if (request.usrName != null)
                    updateUser.usrName = request.usrName;
                if (request.usrLastName != null)
                    updateUser.usrLastName = request.usrLastName;
                if (request.usrEmail != null)
                    updateUser.usrEmail = request.usrEmail;
                if (request.usrDomainName != null)
                    updateUser.usrDomainName = request.usrDomainName;
                if (request.rolId != 0)
                    updateUser.rolId = request.rolId;
                if (request.state != null)
                    updateUser.state = request.state;
                updateUser.modifyDate = DateTime.Now;
                updateUser.modifyUser = request.usrId;

                var userEntityGetResponse = await _unitOfWork.Repository<User>().UpdateAsync(updateUser);
                var userEntityResponse = _mapper.Map<UserVm>(userEntityGetResponse);

                ResponseUserVm responseUser = new ResponseUserVm()
                {
                    result = userEntityResponse
                };

                _logger.LogInformation($"El usuario con el id {userEntityGetResponse.usrId} fue actualizado correctamente ");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El usuario con Id {request.usrId} no existe");
            }
        }

    }
}
