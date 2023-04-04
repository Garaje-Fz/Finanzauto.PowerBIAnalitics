using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
using Finanzauto.PowerBI.Application.Features.ParentReports.Commands.CreateParentReport;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.UpdatePermission;
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

namespace Finanzauto.PowerBI.Application.Features.ParentReports.Commands.UpdateParentReport
{
    public class UpdateParentReportCommandHandler : IRequestHandler<UpdateParentReportCommand, ResponseParentReportVm>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateParentReportCommandHandler> _logger;


        public UpdateParentReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateParentReportCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseParentReportVm> Handle(UpdateParentReportCommand request, CancellationToken cancellationToken)
        {
            var updateParentReport = await _unitOfWork.Repository<ParentReport>().GetFirstOrDefaultAsync(x => x.parId == request.parId && x.state == true);

            if (updateParentReport != null)
            {
                updateParentReport.parDescription = request.parDescription;
                updateParentReport.parIcon = request.parIcon;
                updateParentReport.state = request.state;
                updateParentReport.modifyDate = DateTime.Now;
                updateParentReport.modifyUser = 1;

                var parentReportEntityGetResponse = await _unitOfWork.Repository<ParentReport>().UpdateAsync(updateParentReport);
                var parentReportEntityResponse = _mapper.Map<ParentReportVm>(parentReportEntityGetResponse);

                ResponseParentReportVm response = new ResponseParentReportVm()
                {
                    result = parentReportEntityResponse                           

                };

                _logger.LogInformation($"El reporte padre ha sido actualizado fue creado con el id {updateParentReport.parId}");


                return response;

            }
            else
            {
                throw new BadRequestException($"El reporte padre con Id {request.parId} no ha sido actualizado");
            }
        }
    }
}
