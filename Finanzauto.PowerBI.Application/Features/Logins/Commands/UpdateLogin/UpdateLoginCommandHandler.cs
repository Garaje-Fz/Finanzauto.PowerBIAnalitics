using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
using Finanzauto.PowerBI.Application.Features.Users.Commands.UpdateUser;
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

namespace Finanzauto.PowerBI.Application.Features.Logins.Commands.UpdateLogin
{
    public class UpdateLoginCommandHandler : IRequestHandler<UpdateLoginCommand, ResponseLoginVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateLoginCommandHandler> _logger;
        public UpdateLoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateLoginCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseLoginVm> Handle(UpdateLoginCommand request, CancellationToken cancellationToken)
        {
            var updateLogin = await _unitOfWork.Repository<Login>().GetFirstOrDefaultAsync(x => x.lgnId == request.lgnId && x.state == true);

            if (updateLogin != null)
            {
                updateLogin.lgnLastConnection = request.lgnLastConnection;
                updateLogin.lgnConnectionTimes = request.lgnConnectionTimes;
                updateLogin.usrId = request.usrId;
                updateLogin.state = request.state;
                updateLogin.modifyDate = DateTime.Now;
                updateLogin.modifyUser = request.usrId;

                var loginEntityGetResponse = await _unitOfWork.Repository<Login>().UpdateAsync(updateLogin);
                var loginEntityResponse = _mapper.Map<LoginVm>(loginEntityGetResponse);

                ResponseLoginVm responseUser = new ResponseLoginVm()
                {
                    result = loginEntityResponse
                };

                _logger.LogInformation($"El login con el id {loginEntityGetResponse.usrId} fue actualizado correctamente ");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El usuario con Id {request.usrId} no existe");
            }
        }

    }
}
