using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser;
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

namespace Finanzauto.PowerBI.Application.Features.Logs.Queries.ListLog
{
    public class ListLogQueryHandler : IRequestHandler<ListLogQuery, ResponseListLogVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListLogQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListLogQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListLogQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseListLogVm ResponseListLogVm { get; private set; }

        public async Task<ResponseListLogVm> Handle(ListLogQuery request, CancellationToken cancellationToken)
        {
            if (request.LogId != null)
            {
                var log = await _unitOfWork.Repository<Log>().GetAsync(x => x.logId == request.LogId);
                var logVm = _mapper.Map<List<ListLogVm>>(log);

                ResponseListLogVm response = new ResponseListLogVm()
                {
                    result = logVm
                };
                return response;

            }
            else
            {
                var log = await _unitOfWork.Repository<Log>().GetAllAsync();
                var logVm = _mapper.Map<List<ListLogVm>>(log);


                ResponseListLogVm response = new ResponseListLogVm()
                {
                    result = logVm
                };
                return response;
            }

            return ResponseListLogVm;

        }
    }
}
