using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Logins.Commands.CreateLogin
{
    public class CreateLoginCommand : IRequest<ResponseLoginVm>
    {
        public string lgnIp { get; set; }
        public int lgnConnectionTimes { get; set; }
        public DateTime lgnLastConnection { get; set; }
        public int usrId { get; set; }
        public bool state { get; set; }
        public DateTime createDate { get; set; }
        public int createUser { get; set; }
    }
}
