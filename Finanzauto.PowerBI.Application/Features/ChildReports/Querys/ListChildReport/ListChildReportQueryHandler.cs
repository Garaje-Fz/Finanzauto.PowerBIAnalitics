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

namespace Finanzauto.PowerBI.Application.Features.ChildReports.Querys.ListChildReport
{
    public class ListChildReportQueryHandler : IRequestHandler<ListChildReportQuery, ResponseListChildReportVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListChildReportQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListChildReportQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListChildReportQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseListChildReportVm ResponseListChildReportVm { get; private set; }

        public async Task<ResponseListChildReportVm> Handle(ListChildReportQuery request, CancellationToken cancellationToken)
        {
            if (request.ChId != null)
            {
                var childReport = await _unitOfWork.Repository<ChildReport>().GetAsync(x => x.chId == request.ChId);
                var childReportVm = _mapper.Map<List<ListChildReportVm>>(childReport);

                ResponseListChildReportVm response = new ResponseListChildReportVm()
                {
                    result = childReportVm
                };
                return response;

            }
            else
            {
                var childReport = await _unitOfWork.Repository<ChildReport>().GetAllAsync();
                var childReportVm = _mapper.Map<List<ListChildReportVm>>(childReport);

                ResponseListChildReportVm response = new ResponseListChildReportVm()
                {
                    result = childReportVm
                };
                return response;

            }


            return ResponseListChildReportVm;
        }
    }
}
