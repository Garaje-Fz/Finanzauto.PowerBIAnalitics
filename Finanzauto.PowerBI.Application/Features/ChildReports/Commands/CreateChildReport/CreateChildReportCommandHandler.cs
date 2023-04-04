using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Exceptions;
using Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser;
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

namespace Finanzauto.PowerBI.Application.Features.ChildReports.Commands.CreateChildReport
{
    public class CreateChildReportCommandHandler : IRequestHandler<CreateChildReportCommand, ResponseChildReportVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateChildReportCommandHandler> _logger;

        public CreateChildReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateChildReportCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseChildReportVm> Handle(CreateChildReportCommand request, CancellationToken cancellationToken)
        {
            var VerifiChildReport = await _unitOfWork.Repository<ChildReport>().GetFirstOrDefaultAsync(x => x.chiDescription == request.chiDescription && x.state == true);

            if (VerifiChildReport == null)
            {
                var childReportEntity = _mapper.Map<ChildReport>(request);
                var childReportEntityAdd = await _unitOfWork.Repository<ChildReport>().AddAsync(childReportEntity);
                var childReportEntityResponse = _mapper.Map<ChildReportVm>(childReportEntityAdd);

                ResponseChildReportVm responseUser = new ResponseChildReportVm()
                {
                    result = childReportEntityResponse

                };

                _logger.LogInformation($"El reporte hijo fue creado con el id {childReportEntityAdd.chId}");


                return responseUser;

            }
            else
            {
                throw new BadRequestException($"El reporte hijo {request.chiDescription} ya existe");
            }
        }
    }
}
