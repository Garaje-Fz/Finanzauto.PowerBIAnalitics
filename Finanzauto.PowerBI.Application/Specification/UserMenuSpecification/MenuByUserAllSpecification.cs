using Finanzauto.PowerBI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Specification.UserMenuSpecification
{
    public class MenuByUserAllSpecification : Specification<User>
    {
        public MenuByUserAllSpecification(int? UsrId) : base
            (
            cr => cr.usrId == UsrId
            )
        {
            AddInclude(i => i.Permissions);
            AddInclude($"{nameof(User.Permissions)}");
            AddInclude($"{nameof(User.Permissions)}.{nameof(Permission.ChildReport)}");
            AddInclude($"{nameof(User.Permissions)}.{nameof(Permission.ChildReport)}.{nameof(ChildReport.ParentReport)}");
        }


    }
}
