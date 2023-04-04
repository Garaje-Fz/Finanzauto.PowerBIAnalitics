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

namespace Finanzauto.PowerBI.Application.Features.Roles.Queries.ListRol
{
    public class ListRolQueryHandler : IRequestHandler<ListRolQuery, ResponseListRolVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListRolQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListRolQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListRolQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseListRolVm ResponseListRolVm { get; private set; }

        public async Task<ResponseListRolVm> Handle(ListRolQuery request, CancellationToken cancellationToken)
        {
            if (request.RolId != null)
            {
                var rol = await _unitOfWork.Repository<Rol>().GetAsync(x => x.rolId == request.RolId);
                var rolVm = _mapper.Map<List<ListRolVm>>(rol);

                ResponseListRolVm response = new ResponseListRolVm()
                {
                    result = rolVm
                };
                return response;

            }
            else
            {
                var rol = await _unitOfWork.Repository<Rol>().GetAllAsync();
                var rolVm = _mapper.Map<List<ListRolVm>>(rol);

                ResponseListRolVm response = new ResponseListRolVm()
                {
                    result = rolVm
                };
                return response;

            }
            return ResponseListRolVm;
        }
    }
}
