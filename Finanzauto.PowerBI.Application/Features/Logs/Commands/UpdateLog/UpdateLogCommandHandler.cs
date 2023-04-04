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

namespace Finanzauto.PowerBI.Application.Features.Logs.Commands.UpdateLog
{
    public class UpdateLogCommandHandler : IRequestHandler<UpdateLogCommand, ResponseLogVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateLogCommandHandler> _logger;
        public UpdateLogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateLogCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseLogVm> Handle(UpdateLogCommand request, CancellationToken cancellationToken)
        {
            var updateLog = await _unitOfWork.Repository<Log>().GetFirstOrDefaultAsync(x => x.usrId == request.usrId && x.state == true);

            if (updateLog != null)
            {
                updateLog.logId = request.logId;
                updateLog.usrId = request.usrId;
                updateLog.chId = request.chiIld;
                updateLog.logLastConnection = request.logLastConnection;
                updateLog.logPrintTimes = request.logPrintTimes;
                updateLog.state = request.state;
                updateLog.modifyDate = DateTime.Now;
                updateLog.modifyUser = request.usrId;

                var logEntityGetResponse = await _unitOfWork.Repository<Log>().UpdateAsync(updateLog);
                var logEntityResponse = _mapper.Map<LogVm>(logEntityGetResponse);

                ResponseLogVm responseUser = new ResponseLogVm()
                {
                    result = logEntityResponse
                };

                _logger.LogInformation($"El log con el id {logEntityGetResponse.logId} fue actualizado correctamente ");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El log con Id {request.logId} no existe");
            }
        }
    }
}
