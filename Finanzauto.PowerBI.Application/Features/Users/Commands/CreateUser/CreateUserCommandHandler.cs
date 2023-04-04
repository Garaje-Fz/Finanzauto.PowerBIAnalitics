using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
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

namespace Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseUserVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseUserVm> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var VerifiUser = await _unitOfWork.Repository<User>().GetFirstOrDefaultAsync(x => x.usrDomainName == request.usrDomainName && x.state == true);

            if (VerifiUser == null)
            {
                var userEntity = _mapper.Map<User>(request);
                var userEntityAdd = await _unitOfWork.Repository<User>().AddAsync(userEntity);
                var userEntityResponse = _mapper.Map<UserVm>(userEntityAdd);

                ResponseUserVm responseUser = new ResponseUserVm()
                {
                    result = userEntityResponse

                };

                _logger.LogInformation($"El usuario fue creado con el id {userEntityAdd.usrId}");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El usuario con Dominio {request.usrDomainName} ya existe");
            }

        }

    }
}
