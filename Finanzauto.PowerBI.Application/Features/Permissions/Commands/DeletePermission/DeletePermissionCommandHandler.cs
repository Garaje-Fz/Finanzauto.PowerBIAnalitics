using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUserPermission;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Domain;
using Finanzauto.PowerBI.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Finanzauto.PowerBI.Application.Features.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeletePermissionCommandHandler> _logger;
        private readonly IMapper _mapper;


        public DeletePermissionCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<DeletePermissionCommandHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public bool DeleteOption { get; private set; }

        public async Task<int> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {

            if (!request.PerId.Equals(null))
            {
                var DeleteModulePermission = await _unitOfWork.Repository<Permission>().GetFirstOrDefaultAsync(x => x.perId == request.PerId);

                if (DeleteModulePermission != null)
                {
                    await _unitOfWork.Repository<Permission>().DeleteAsync(DeleteModulePermission);

                    return 1;
                }
                else
                {
                    return 0;

                }

            }
            else
            {
                return 0;

            }
        }


    }
}
