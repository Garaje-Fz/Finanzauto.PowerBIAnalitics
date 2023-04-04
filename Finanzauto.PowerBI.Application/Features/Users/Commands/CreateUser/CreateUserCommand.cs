using Finanzauto.PowerBI.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public bool state { get; set; } = true;
        [JsonIgnore]
        public DateTime createDate { get; set; } = DateTime.Now;
        
        public int createUser { get; set; }
    }
}
