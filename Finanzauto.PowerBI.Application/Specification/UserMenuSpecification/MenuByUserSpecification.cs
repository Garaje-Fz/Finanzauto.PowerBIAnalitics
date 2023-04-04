using Finanzauto.PowerBI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Specification.UserMenuSpecification
{
    public class MenuByUserSpecification : Specification<User>
    {
        public MenuByUserSpecification() : base()

        {
            //AddInclude(a => a.Permission);
            //AddInclude($"{nameof(User.Permission)}");
            //AddInclude($"{nameof(User.Permission)}.{nameof(Permission.ChildReport)}");
            //AddInclude($"{nameof(User.Permission)}.{nameof(Permission.ChildReport)}.{nameof(ChildReport.ParentReport)}");
        }
    }
}
