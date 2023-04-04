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

namespace Finanzauto.PowerBI.Application.Features.ChildReports.Commands.UpdateChildReport
{
    public class UpdateChildReportCommandHandler : IRequestHandler<UpdateChildReportCommand, ResponseChildReportVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateChildReportCommandHandler> _logger;
        public UpdateChildReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateChildReportCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseChildReportVm> Handle(UpdateChildReportCommand request, CancellationToken cancellationToken)
          {
             var updateChildReport = await _unitOfWork.Repository<ChildReport>().GetFirstOrDefaultAsync(x => x.chId == request.chiId && x.state == true);

            if (updateChildReport != null)
            {
                updateChildReport.chiDescription = request.chiDescripcion;
                updateChildReport.chiUrl = request.chiUrl;
                updateChildReport.parId = request.parId;
                updateChildReport.state = request.state;
                updateChildReport.modifyDate = DateTime.Now;
                updateChildReport.modifyUser = 1;

                var childReportEntityGetResponse = await _unitOfWork.Repository<ChildReport>().UpdateAsync(updateChildReport);
                var childReportEntityResponse = _mapper.Map<ChildReportVm>(childReportEntityGetResponse);

                ResponseChildReportVm responseUser = new ResponseChildReportVm()
                {
                    result = childReportEntityResponse
                };

                _logger.LogInformation($"El usuario con el id {childReportEntityResponse.chId} fue actualizado correctamente ");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El usuario con Id {request.chiId} no existe");
            }
        }
    }
}
