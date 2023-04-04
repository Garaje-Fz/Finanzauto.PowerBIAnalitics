using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logins.Queries.ListLogin
{
    public class ListLoginQuery : IRequest<ResponseListLoginVm>
    {
        public ListLoginQuery(int? lgnId)
        {
            LgnId = lgnId;
        }
        public int? LgnId { get; set; }
    }
}
