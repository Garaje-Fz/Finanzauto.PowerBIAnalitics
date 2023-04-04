using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logins.Commands.UpdateLogin
{
    public class UpdateLoginCommand : IRequest<ResponseLoginVm>
    {
        public int lgnId { get; set; }
        public string lgnIp { get; set; }
        public int lgnConnectionTimes { get; set; }
        public DateTime lgnLastConnection { get; set; }
        public int usrId { get; set; }
        public bool state { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
