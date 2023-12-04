using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUserPermission;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Application.Models.ViewModel.MenuListChildVm;
using Finanzauto.PowerBI.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListAllChildByUser
{
    public class ListAllChildByUserQueryHandler : IRequestHandler<ListAllChildByUserQuery, GetListAllChildByUserVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListAllChildByUserQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListAllChildByUserQueryHandler(IUnitOfWork unitOfWork, ILogger<ListAllChildByUserQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetListAllChildByUserVm> Handle(ListAllChildByUserQuery request, CancellationToken cancellationToken)
        {
            var parentVM = new List<ListParentChildVm>();
            var childVM = new List<ListChildPermissionsVm>();

            if (request.UsrId != null)
            {
                var parents = await _unitOfWork.Repository<ParentReport>().GetAllAsync();
                foreach (var parent in parents)
                {
                    childVM = new List<ListChildPermissionsVm>();
                    var childs = await _unitOfWork.Repository<ChildReport>().GetAsync(x => x.parId == parent.parId);
                    foreach (var child in childs)
                    {
                        var permissions = await _unitOfWork.Repository<Permission>().GetFirstOrDefaultAsync(x => x.usrId == request.UsrId && x.chilId == child.chId);
                        if (permissions != null)
                        {
                            if (permissions.state == true)
                            {
                                childVM.Add(new ListChildPermissionsVm()
                                {
                                    chId = child.chId,
                                    chiDescription = child.chiDescription,
                                    chiUrl = child.chiUrl,
                                    Status = true
                                });
                            }
                            else
                            {
                                childVM.Add(new ListChildPermissionsVm()
                                {
                                    chId = child.chId,
                                    chiDescription = child.chiDescription,
                                    chiUrl = child.chiUrl,
                                    Status = false
                                });
                            }
                        }
                        else
                        {
                            childVM.Add(new ListChildPermissionsVm()
                            {
                                chId = child.chId,
                                chiDescription = child.chiDescription,
                                chiUrl = child.chiUrl,
                                Status = false
                            });
                        }
                    }
                    parentVM.Add(new ListParentChildVm()
                    {
                        parId = parent.parId,
                        parDescription = parent.parDescription,
                        parIcon = parent.parIcon,
                        items = childVM
                    });
                }
                return new GetListAllChildByUserVm()
                {
                    usrId = request.UsrId,
                    menu = parentVM,
                    data = false
                };
            }
            return null;
        }
    }
}
