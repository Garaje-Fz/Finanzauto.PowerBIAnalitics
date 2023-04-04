using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Features.Permissions.Queries.ListPermission;
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

namespace Finanzauto.PowerBI.Application.Features.ParentReports.Queries.ListParentReport
{
    public class ListParentReportQueryHandler : IRequestHandler<ListParentReportQuery, ResponseListParentReportVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListParentReportQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListParentReportQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListParentReportQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseListParentReportVm ResponseListParentReportVm { get; private set; }
        public async Task<ResponseListParentReportVm> Handle(ListParentReportQuery request, CancellationToken cancellationToken)
        {
            if (request.ParId != null)
            {
                var parentReport = await _unitOfWork.Repository<ParentReport>().GetAsync(x => x.parId == request.ParId);
                var parentReportVm = _mapper.Map<List<ListParentReportVm>>(parentReport);

                ResponseListParentReportVm response = new ResponseListParentReportVm()
                {
                    result = parentReportVm
                };
                return response;

            }
            else
            {
                var parentReport = await _unitOfWork.Repository<ParentReport>().GetAllAsync();
                var parentReportVm = _mapper.Map<List<ListParentReportVm>>(parentReport);


                ResponseListParentReportVm response = new ResponseListParentReportVm()
                {
                    result = parentReportVm
                };
                return response;
            }

            return ResponseListParentReportVm;
        }
    }
}
