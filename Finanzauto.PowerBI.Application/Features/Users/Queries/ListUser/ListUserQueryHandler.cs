using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
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

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser
{
    public class ListUserQueryHandler : IRequestHandler<ListUserQuery, ResponseListUserVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListUserQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListUserQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListUserQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseListUserVm ResponseListUserVm { get; private set; }

        public async Task<ResponseListUserVm> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            if (request.UsrDomainName != null)
            {
                var user = await _unitOfWork.Repository<User>().GetAsync(x => x.usrDomainName == request.UsrDomainName);
                var userVm = _mapper.Map<List<ListUserVm>>(user);

                ResponseListUserVm response = new ResponseListUserVm()
                {
                    result = userVm
                };
                return response;

            }
            else
            {
                var rol = await _unitOfWork.Repository<User>().GetAllAsync();
                var rolVm = _mapper.Map<List<ListUserVm>>(rol);

                ResponseListUserVm response = new ResponseListUserVm()
                {
                    result = rolVm
                };
                return response;

            }
            return ResponseListUserVm;
        }
    }
}
