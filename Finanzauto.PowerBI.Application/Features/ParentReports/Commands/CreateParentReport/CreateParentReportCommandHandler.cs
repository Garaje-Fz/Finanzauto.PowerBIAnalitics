using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.CreatePermission;
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

namespace Finanzauto.PowerBI.Application.Features.ParentReports.Commands.CreateParentReport
{
    public class CreateParentReportCommandHandler : IRequestHandler<CreateParentReportCommand, ResponseParentReportVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateParentReportCommandHandler> _logger;


        public CreateParentReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateParentReportCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseParentReportVm> Handle(CreateParentReportCommand request, CancellationToken cancellationToken)
        {
            var VerifiParentReport = await _unitOfWork.Repository<ParentReport>().GetFirstOrDefaultAsync(x => x.parDescription == request.parDescription && x.state == true);

            if (VerifiParentReport == null)
            {
                var parentReportEntity = _mapper.Map <ParentReport>(request);
                var parentReportEntityAdd = await _unitOfWork.Repository<ParentReport>().AddAsync(parentReportEntity);
                var parentReportEntityResponse = _mapper.Map<ParentReportVm>(parentReportEntityAdd);

                ResponseParentReportVm response = new ResponseParentReportVm()
                {
                    result = parentReportEntityResponse

                };

                _logger.LogInformation($"El reporte padre fue creado con la descripcion {parentReportEntityAdd.parDescription}");


                return response;

            }
            else
            {
                throw new BadRequestException($"El reporte padre {request.parIcon} ya existe");
            }
        }
    }
}
