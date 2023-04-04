using AutoMapper;
using Finanzauto.PowerBI.Application.Features.ChildReports.Commands.CreateChildReport;
using Finanzauto.PowerBI.Application.Features.ChildReports.Commands.UpdateChildReport;
using Finanzauto.PowerBI.Application.Features.Logins.Commands.CreateLogin;
using Finanzauto.PowerBI.Application.Features.Logins.Commands.UpdateLogin;
using Finanzauto.PowerBI.Application.Features.Logs.Commands.CreateLog;
using Finanzauto.PowerBI.Application.Features.Logs.Commands.UpdateLog;
using Finanzauto.PowerBI.Application.Features.ParentReports.Commands.CreateParentReport;
using Finanzauto.PowerBI.Application.Features.ParentReports.Commands.UpdateParentReport;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.CreatePermission;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.DeletePermission;
using Finanzauto.PowerBI.Application.Features.Permissions.Commands.UpdatePermission;
using Finanzauto.PowerBI.Application.Features.Roles.Commands.CreateRol;
using Finanzauto.PowerBI.Application.Features.Roles.Commands.UpdateRol;
using Finanzauto.PowerBI.Application.Features.Users.Commands.CreateUser;
using Finanzauto.PowerBI.Application.Features.Users.Commands.UpdateUser;
using Finanzauto.PowerBI.Application.Features.Users.Queries.ListUser;
using Finanzauto.PowerBI.Application.Models.ViewModel;
using Finanzauto.PowerBI.Application.Specification.UserMenuSpecification;
using Finanzauto.PowerBI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserVm>();
            CreateMap<User, ListUserVm>();
            CreateMap<User, MenuByUserAllSpecification>();
            //Mapeo menu con especificaciones
            CreateMap<User, ResponseMenuVm>().ForMember(dest=>dest.PermissionMenu,opt=>opt.MapFrom(src=>src.Permissions));
            CreateMap<Permission, PermissionMenuVm>().ForMember(dest => dest.Menu, opt => opt.MapFrom(src => src.ChildReport));
            CreateMap<ChildReport, MenuVm>().ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.ParentReport));
            
            CreateMap<User, ResponseMenuVm>();
            CreateMap<Permission, ResponseMenuVm>();
            CreateMap<ParentReport, MenuVm>();
            CreateMap<ChildReport, ResponseItemVm>();


            CreateMap<CreateRolCommand, Rol>();
            CreateMap<UpdateRolCommand, Rol>();
            CreateMap<Rol, RolVm>();
            CreateMap<Rol, ListRolVm>();

            CreateMap<CreatePermissionCommand, Permission>();
            CreateMap<UpdatePermissionCommand, Permission>();
            CreateMap<DeletePermissionCommand, Permission>();
            CreateMap<Permission, PermissionVm>();
            CreateMap<Permission, ListPermissionVm>();

            CreateMap<CreateParentReportCommand, ParentReport>();
            CreateMap<UpdateParentReportCommand, ParentReport>();
            CreateMap<ParentReport, ParentReportVm>();
            CreateMap<ParentReport, ListParentReportVm>();

            CreateMap<CreateLogCommand, Log>();
            CreateMap<UpdateLogCommand, Log>();
            CreateMap<Log, LogVm>();
            CreateMap<Log, ListLogVm>();

            CreateMap<CreateLoginCommand, Login>();
            CreateMap<UpdateLoginCommand, Login>();
            CreateMap<Login, LoginVm>();
            CreateMap<Login, ListLoginVm>();

            CreateMap<CreateChildReportCommand, ChildReport>();
            CreateMap<UpdateChildReportCommand, ChildReport>();
            CreateMap<ChildReport, ChildReportVm>();
            CreateMap<ChildReport, ListChildReportVm>();
            CreateMap<ChildReport, ResponseItemVm>();


            //var @types = new Dictionary<Type, Type>
            //{
            //    { typeof(ResponseMenuVm), typeof(User) },
            //    { typeof(MenuVm), typeof(ParentReport) },
            //    { typeof(ResponseItemVm), typeof(ChildReport) }

            //};
        }
    }
}
