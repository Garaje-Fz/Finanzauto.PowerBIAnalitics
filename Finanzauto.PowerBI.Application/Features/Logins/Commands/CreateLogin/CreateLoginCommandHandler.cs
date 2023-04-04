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

namespace Finanzauto.PowerBI.Application.Features.Logins.Commands.CreateLogin
{
    public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, ResponseLoginVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLoginCommandHandler> _logger;

        public CreateLoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateLoginCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseLoginVm> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            var VerifiUser = await _unitOfWork.Repository<Login>().GetFirstOrDefaultAsync(x => x.lgnIp == request.lgnIp && x.state == true);

            if (VerifiUser == null)
            {
                var loginEntity = _mapper.Map<Login>(request);
                var loginEntityAdd = await _unitOfWork.Repository<Login>().AddAsync(loginEntity);
                var loginEntityResponse = _mapper.Map<LoginVm>(loginEntityAdd);

                ResponseLoginVm responseUser = new ResponseLoginVm()
                {
                    result = loginEntityResponse

                };

                _logger.LogInformation($"El login se registrto con el id {loginEntityAdd.usrId}");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El usuario con ip {request.lgnIp} ya existe");
            }

        }
    }
}
