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

namespace Finanzauto.PowerBI.Application.Features.Permissions.Queries.ListPermission
{
    public class ListPermissionQueryHandler : IRequestHandler<ListPermissionQuery, ResponseListPermissionVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListPermissionQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListPermissionQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListPermissionQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseListPermissionVm ResponseListPermissionVm { get; private set; }

        public async Task<ResponseListPermissionVm> Handle(ListPermissionQuery request, CancellationToken cancellationToken)
        {
            if (request.usrId!= null)
            {
                var permission = await _unitOfWork.Repository<Permission>().GetAsync(x => x.usrId == request.usrId);
                var permissionVm = new List<ListPermissionVm>();
                foreach (var item in permission)
                {
                    permissionVm.Add(new ListPermissionVm()
                    {
                        usrId = item.usrId,
                        chId = item.chilId,
                        state = item.state,
                        createDate = item.createDate,
                        createUser = item.createUser,
                        modifyDate = item.modifyDate,
                        modifyUser = item.modifyUser,
                    });
                }
                ResponseListPermissionVm response = new ResponseListPermissionVm()
                {
                    result = permissionVm
                };
                return response;

            }
            else
            {
                var permission = await _unitOfWork.Repository<Permission>().GetAllAsync();
                //var permissionVm = _mapper.Map<List<ListPermissionVm>>(permission);
                var permissionVm = new List<ListPermissionVm>();
                foreach (var item in permission)
                {
                    permissionVm.Add(new ListPermissionVm()
                    {
                        usrId = item.usrId,
                        chId = item.chilId,
                        state = item.state,
                        createDate = item.createDate,
                        createUser = item.createUser,
                        modifyDate = item.modifyDate,
                        modifyUser = item.modifyUser,
                    });
                }

                ResponseListPermissionVm response = new ResponseListPermissionVm()
                {
                    result = permissionVm
                };
                return response;

            }
            return ResponseListPermissionVm;

        }
    }
}
