using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ResponseUserVm>
    {
        public string usrName { get; set; }
        public string usrLastName { get; set; }
        public string usrEmail { get; set; }
        public string usrDomainName { get; set; }
        public int rolId { get; set; }
        public bool state { get; set; }
        public DateTime createDate { get; set; }
        public int createUser { get; set; }
    }
}
