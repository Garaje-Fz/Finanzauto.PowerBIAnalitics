using AutoMapper;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
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

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListUserPermission
{
    public class ListMenuQueryHandler : IRequestHandler<ListMenuQuery, GetUserMenuVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListMenuQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListMenuQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListMenuQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<GetUserMenuVm> Handle(ListMenuQuery request, CancellationToken cancellationToken)
        {
            var parentVM = new List<ParentVm>();
            var childVM = new List<ChildVm>();

            if (request.UsrId != null)
            {
                var permisions = await _unitOfWork.Repository<Permission>().GetAsync(x => x.usrId == request.UsrId);
                if (permisions != null)
                {
                    if (permisions.Count == 0)
                    {
                        childVM.Add(new ChildVm()
                        {
                            chId = 0,
                            chiDescription = "",
                            chiUrl = ""
                        });
                        parentVM.Add(new ParentVm()
                        {
                            parId = 0,
                            parDescription = "",
                            parIcon = "",
                            items = childVM
                        });
                        return new GetUserMenuVm()
                        {
                            usrId = 0,
                            menu = parentVM,
                            data = false
                        };
                    }
                    var child = await _unitOfWork.Repository<ChildReport>().GetAllAsync();
                    for (int i = 0; i < permisions.Count; i++)
                    {
                        child = await _unitOfWork.Repository<ChildReport>().GetAsync(x => x.chId == permisions[i].chilId);
                        for (int j = 0; j < child.Count; j++)
                        {
                            childVM.Add(new ChildVm()
                            {
                                chId = child[j].chId,
                                chiDescription = child[j].chiDescription,
                                chiUrl = child[j].chiUrl
                            });
                        }
                        var parent = await _unitOfWork.Repository<ParentReport>().GetAsync(x => x.parId == child[0].parId);
                        parentVM.Add(new ParentVm()
                        {
                            parId = child[0].parId,
                            parDescription = parent[0].parDescription,
                            parIcon = parent[0].parIcon,
                            items = childVM
                        });
                    }
                    return new GetUserMenuVm()
                    {
                        usrId = permisions[0].usrId,
                        menu = parentVM,
                        data = true

                    };
                }
                else
                {
                    childVM.Add(new ChildVm()
                    {
                        chId = 0,
                        chiDescription = "",
                        chiUrl = ""
                    });
                    parentVM.Add(new ParentVm()
                    {
                        parId = 0,
                        parDescription = "",
                        parIcon = "",
                        items = childVM
                    });
                    return new GetUserMenuVm()
                    {
                        usrId = 0,
                        menu = parentVM,
                        data = false
                    };
                }


            }
            else
            {
                var permisions = await _unitOfWork.Repository<Permission>().GetAllAsync();
                var child = await _unitOfWork.Repository<ChildReport>().GetAllAsync();
                for (int i = 0; i < permisions.Count; i++)
                {
                    child = await _unitOfWork.Repository<ChildReport>().GetAsync(x => x.chId == permisions[i].chilId);
                    for (int j = 0; j < child.Count; j++)
                    {
                        childVM.Add(new ChildVm()
                        {
                            chId = child[j].chId,
                            chiDescription = child[j].chiDescription,
                            chiUrl = child[j].chiUrl
                        });
                    }
                    var parent = await _unitOfWork.Repository<ParentReport>().GetAsync(x => x.parId == child[0].parId);
                    parentVM.Add(new ParentVm()
                    {
                        parId = child[0].parId,
                        parDescription = parent[0].parDescription,
                        parIcon = parent[0].parIcon,
                        items = childVM
                    });
                }
                return new GetUserMenuVm()
                {
                    usrId = permisions[0].usrId,
                    menu = parentVM,
                    data = true

                };
            }
        }
    }
}
