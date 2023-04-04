using Finanzauto.PowerBI.Domain;
using Finanzauto.PowerBI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Infraestructure.Persistence
{
    public class PowerBIDbContext : DbContext
    {

        public PowerBIDbContext(DbContextOptions options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.createDate = DateTime.Now;
                        entry.Entity.createUser = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.modifyDate = DateTime.Now;
                        entry.Entity.modifyUser = 1;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Registros creados por defecto en la base de datos
            List<Rol> RolInit = new List<Rol>();
            RolInit.Add(new Rol
            {
                rolId = 1,
                rolDescription = "Estratégico",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,
            });

            RolInit.Add(new Rol
            {
                rolId = 2,
                rolDescription = "Táctico",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,
            });

            RolInit.Add(new Rol
            {
                rolId = 3,
                rolDescription = "Operativo",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,
            });

            RolInit.Add(new Rol
            {
                rolId = 4,
                rolDescription = "Administrador",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,
            });

            RolInit.Add(new Rol
            {
                rolId = 5,
                rolDescription = "Default",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,
            });

            List<User> UserInit = new List<User>();
            UserInit.Add(new User
            {
                usrId = 100,
                rolId = 1,
                usrLastName = "Gonzales",
                usrDomainName = "milton.gonzales",
                usrEmail = "milton.gonzales@finanzauto.com",
                usrName = "Milton",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            UserInit.Add(new User
            {
                usrId = 101,
                rolId = 1,
                usrLastName = "Cruz",
                usrDomainName = "hector.cruz",
                usrEmail = "hector.cruz@finanzauto.com",
                usrName = "Hector",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            UserInit.Add(new User
            {
                usrId = 102,
                rolId = 1,
                usrLastName = "Guzman",
                usrDomainName = "enrique.guzman",
                usrEmail = "enrique.guzman@finanzauto.com",
                usrName = "Enrique",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            List<ParentReport> ParentReportInit = new List<ParentReport>();
            ParentReportInit.Add(new ParentReport
            {
                parId = 1,
                parDescription = "Reportes Estratégicos",
                parIcon = "icon_estrategic.png",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ParentReportInit.Add(new ParentReport
            {
                parId = 2,
                parDescription = "Reportes Tácticos",
                parIcon = "icon_tactic.png",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ParentReportInit.Add(new ParentReport
            {
                parId = 3,
                parDescription = "Reportes Operacionales",
                parIcon = "icon_operational.png",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ParentReportInit.Add(new ParentReport
            {
                parId = 4,
                parDescription = "Administrador",
                parIcon = "icon_administration.png",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            List<ChildReport> ChildReportInit = new List<ChildReport>();
            ChildReportInit.Add(new ChildReport
            {
                chId = 1,
                parId = 1,
                chiDescription = "Reporte Estratégico # 1",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ9",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ChildReportInit.Add(new ChildReport
            {
                chId = 2,
                parId = 1,
                chiDescription = "Reporte Estratégico # 2 ",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ10",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ChildReportInit.Add(new ChildReport
            {
                chId = 3,
                parId = 1,
                chiDescription = "Reporte Estratégico # 3",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ11",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ChildReportInit.Add(new ChildReport
            {
                chId = 4,
                parId = 2,
                chiDescription = "Reporte Táctico # 1",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ12",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            }); 

            ChildReportInit.Add(new ChildReport
            {
                chId = 5,
                parId = 2,
                chiDescription = "Reporte Táctico # 2",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ13",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            }); 
            ChildReportInit.Add(new ChildReport
            {
                chId = 6,
                parId = 2,
                chiDescription = "Reporte Táctico # 3",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ13",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            }); 
            ChildReportInit.Add(new ChildReport
            {
                chId = 7,
                parId = 3,
                chiDescription = "Reporte Operativo # 1",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ15\r\n",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ChildReportInit.Add(new ChildReport
            {
                chId = 8,
                parId = 3,
                chiDescription = "Reporte Operativo # 2",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ16\r\n",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });

            ChildReportInit.Add(new ChildReport
            {
                chId = 9,
                parId = 3,
                chiDescription = "Reporte Táctico # 3",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ17\r\n",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });

            ChildReportInit.Add(new ChildReport
            {
                chId = 10,
                parId = 4,
                chiDescription = "Gestión de Permisos",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ18\r\n",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ChildReportInit.Add(new ChildReport
            {
                chId = 11,
                parId = 4,
                chiDescription = "Gestión de Permisos",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ19\r\n",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });

            List<Permission> PermissionInit = new List<Permission>();
            PermissionInit.Add(new Permission
            {
                perId =1,
                usrId = 100,
                chilId = 7,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            PermissionInit.Add(new Permission
            {
                perId = 2,
                usrId = 100,
                chilId = 8,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            PermissionInit.Add(new Permission
            {
                perId = 3,
                usrId = 100,
                chilId = 9,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            PermissionInit.Add(new Permission
            {
                perId = 4,
                usrId = 101,
                chilId = 11,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            List<Login> LoginInit = new List<Login>();
            LoginInit.Add(new Login
            {
                lgnId = 1,
                usrId = 100,
                lgnIp = "123.12.36.98",
                state = true,
                lgnConnectionTimes = 10,
                lgnLastConnection = DateTime.Now,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            LoginInit.Add(new Login
            {
                lgnId = 3,
                usrId = 101,
                lgnIp = "123.12.36.98",
                lgnConnectionTimes = 10,
                lgnLastConnection = DateTime.Now,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            LoginInit.Add(new Login
            {
                lgnId = 3,
                usrId = 102,
                lgnIp = "123.12.36.98",
                lgnConnectionTimes = 10,
                lgnLastConnection = DateTime.Now,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            List<Log> LogInit = new List<Log>();
            LogInit.Add(new Log
            {
                logId = 1,
                usrId = 100,
                chId = 2,
                logPrintTimes = 10,
                logLastConnection = DateTime.Now,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            LogInit.Add(new Log
            {
                logId = 1,
                usrId = 101,
                chId = 2,
                logPrintTimes = 10,
                logLastConnection = DateTime.Now,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            LogInit.Add(new Log
            {
                logId = 1,
                usrId = 102,
                chId = 2,
                logPrintTimes = 10,
                logLastConnection = DateTime.Now,
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            #endregion
        }
        public DbSet<ChildReport> ChildReports { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<ParentReport> ParentReports { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

    }
}
