using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Application.Specification.UserMenuSpecification;
using Finanzauto.PowerBI.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListUserPermission
{
    public class ListUserPermissionQueryHandler : IRequestHandler<ListUserPermissionQuery, List<ResponseMenuVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListUserPermissionQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListUserPermissionQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListUserPermissionQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ResponseMenuVm>> Handle(ListUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var spec = new MenuByUserAllSpecification(request.UsrId);
            var menu = await _unitOfWork.Repository<User>().GetAllWithSpec(spec);
            var menuMapped = _mapper.Map<List<ResponseMenuVm>>(menu);

            return menuMapped;
        }

    };
};

