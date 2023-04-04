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
            var updateUser = await _unitOfWork.Repository<User>().GetFirstOrDefaultAsync(x => x.usrId == request.usrId && x.state == true);

            if (updateUser != null)
            {
                updateUser.usrName = request.usrName;
                updateUser.usrLastName = request.usrLastName;
                updateUser.usrDomainName = request.usrDomainName;
                updateUser.rolId = request.rolId;
                updateUser.usrEmail = request.usrEmail;
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
