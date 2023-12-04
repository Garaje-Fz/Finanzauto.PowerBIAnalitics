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

namespace Finanzauto.PowerBI.Application.Features.Roles.Commands.UpdateRol
{
    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, ResponseRolVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateRolCommandHandler> _logger;
        public UpdateRolCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateRolCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseRolVm> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var updateRol = await _unitOfWork.Repository<Rol>().GetFirstOrDefaultAsync(x => x.rolId == request.rolId);

            if (updateRol != null)
            {
                if (request.rolDescription != null)
                    updateRol.rolDescription = request.rolDescription;
                if (request.state != null)
                    updateRol.state = request.state;
                updateRol.modifyDate = DateTime.Now;
                updateRol.modifyUser = request.modifyUser;

                var rolEntityGetResponse = await _unitOfWork.Repository<Rol>().UpdateAsync(updateRol);
                var rolEntityResponse = _mapper.Map<RolVm>(rolEntityGetResponse);

                ResponseRolVm responseUser = new ResponseRolVm()
                {
                    result = rolEntityResponse
                };

                _logger.LogInformation($"El rol con el id {rolEntityGetResponse.rolId} fue actualizado correctamente ");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El rol con Id {request.rolId} no existe");
            }
        }
    }
}
