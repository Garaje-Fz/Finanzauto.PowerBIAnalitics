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

namespace Finanzauto.PowerBI.Application.Features.Logins.Queries.ListLogin
{
    public class ListLoginQueryHandler : IRequestHandler<ListLoginQuery, ResponseListLoginVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListLoginQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListLoginQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListLoginQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseListLoginVm ResponseListLoginVm { get; private set; }

        public async Task<ResponseListLoginVm> Handle(ListLoginQuery request, CancellationToken cancellationToken)
        {
            if (request.LgnId != null)
            {
                var login = await _unitOfWork.Repository<Login>().GetAsync(x => x.lgnId == request.LgnId);
                var loginVm = _mapper.Map<List<ListLoginVm>>(login);

                ResponseListLoginVm response = new ResponseListLoginVm()
                {
                    result = loginVm
                };
                return response;

            }
            else
            {
                var login = await _unitOfWork.Repository<Login>().GetAllAsync();
                var loginVm = _mapper.Map<List<ListLoginVm>>(login);

                ResponseListLoginVm response = new ResponseListLoginVm()
                {
                    result = loginVm
                };
                return response;

            }
            return ResponseListLoginVm;
        }
    }
}
