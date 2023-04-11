using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser
{
    public class ListUserQuery : IRequest<ResponseListUserVm>
    {
        public ListUserQuery(string? usrDomainName, int? usrId)
        {
            UsrDomainName = usrDomainName;
            this.usrId = usrId;
        }
        public int? usrId { get; set; }
        public string? UsrDomainName { get; set; }
    }
}

