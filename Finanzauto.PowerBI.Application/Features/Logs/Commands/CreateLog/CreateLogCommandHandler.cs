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

namespace Finanzauto.PowerBI.Application.Features.Logs.Commands.CreateLog
{
    public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, ResponseLogVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLogCommandHandler> _logger;

        public CreateLogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateLogCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseLogVm> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            var Verifi = await _unitOfWork.Repository<Log>().GetFirstOrDefaultAsync(x => x.logLastConnection == request.logLastConnection && x.state == true);

            if (Verifi == null)
            {
                var Entity = _mapper.Map<Log>(request);
                var EntityAdd = await _unitOfWork.Repository<Log>().AddAsync(Entity);
                var EntityResponse = _mapper.Map<LogVm>(EntityAdd);

                ResponseLogVm responseUser = new ResponseLogVm()
                {
                    result = EntityResponse
                };

                _logger.LogInformation($"El log fue creado con el id {EntityAdd.usrId}");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El log con id {request.logLastConnection} ya existe");
            }

        }

    }
}
