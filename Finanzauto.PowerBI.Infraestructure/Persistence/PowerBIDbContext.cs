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
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Registros creados por defecto en la base de datos

            List<Rol> RolInit = new List<Rol>();

            RolInit.Add(new Rol
            {
                rolId = 1,
                rolDescription = "Administrador",
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });
            RolInit.Add(new Rol
            {
                rolId = 2,
                rolDescription = "Operativo",
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });
            RolInit.Add(new Rol
            {
                rolId = 3,
                rolDescription = "Estrategico",
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });
            RolInit.Add(new Rol
            {
                rolId = 4,
                rolDescription = "Supervisor",
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });
            RolInit.Add(new Rol
            {
                rolId = 5,
                rolDescription = "Default",
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });

            List<User> UserInit = new List<User>();

            UserInit.Add(new User
            {
                usrId = 1,
                usrName = "Efrain",
                usrLastName = "Guzman",
                usrEmail = "efrain.guzman@finanzauto.com.co",
                usrDomainName = "efrain.guzman",
                rolId = 1,
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });
            UserInit.Add(new User
            {
                usrId = 2,
                usrName = "Hector",
                usrLastName = "Cruz",
                usrEmail = "hector.cruz@finanzauto.com.co",
                usrDomainName = "hector.cruz",
                rolId = 1,
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });
            UserInit.Add(new User
            {
                usrId = 3,
                usrName = "Cristian",
                usrLastName = "Vargas",
                usrEmail = "cristian.vargas@finanzauto.com.co",
                usrDomainName = "cristian.vargas",
                rolId = 1,
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });
            UserInit.Add(new User
            {
                usrId = 4,
                usrName = "Julian",
                usrLastName = "Bojaca",
                usrEmail = "julian.bojaca@finanzauto.com.co",
                usrDomainName = "julian.bojaca",
                rolId = 1,
                state = true,
                createDate = DateTime.Now,
                createUser = 1,
            });

            List<ParentReport> ParentReportInit = new List<ParentReport>();

            ParentReportInit.Add(new ParentReport
            {
                parId = 1,
                parIcon = "strategic",
                parDescription = "Reportes Estratégicos",
                state = true,
                createDate = DateTime.Now,
                createUser = 4,

            });
            ParentReportInit.Add(new ParentReport
            {
                parId = 2,
                parIcon = "tactical",
                parDescription = "Reportes Tácticos",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ParentReportInit.Add(new ParentReport
            {
                parId = 3,
                parIcon = "operative",
                parDescription = "Reportes Operacionales",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });
            ParentReportInit.Add(new ParentReport
            {
                parId = 4,
                parIcon = "administrador",
                parDescription = "Reportes Administrador",
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
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ14",
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
                chiDescription = "Gestión de Reportes",
                chiUrl = "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ19\r\n",
                state = true,
                createDate = DateTime.Now,
                createUser = 2140,

            });

            List<Login> LoginInit = new List<Login>();

            LoginInit.Add(new Login
            {
                lgnId = 1,
                lgnIp = "123.12.36.52",
                lgnConnectionTimes = 10,
                lgnLastConnection = DateTime.Now,
                usrId = 1,
                state = true,
                createDate = DateTime.Now,
                createUser = 4,
            });
            LoginInit.Add(new Login
            {
                lgnId = 2,
                lgnIp = "123.12.36.2",
                lgnConnectionTimes = 10,
                lgnLastConnection = DateTime.Now,
                usrId = 1,
                state = true,
                createDate = DateTime.Now,
                createUser = 4,
            });

            #endregion
            modelBuilder.Entity<ChildReport>(child =>
            {
                child.ToTable("ChildReports");
                child.HasKey(x => x.chId);
                child.HasData(ChildReportInit);
            });
            modelBuilder.Entity<Log>(logs =>
            {
                logs.ToTable("Logs");
                logs.HasKey(x => x.logId);
            });
            modelBuilder.Entity<Login>(logins =>
            {
                logins.ToTable("Logins");
                logins.HasKey(x => x.lgnId);
                logins.HasData(LoginInit);
            });
            modelBuilder.Entity<ParentReport>(parent =>
            {
                parent.ToTable("ParentReports");
                parent.HasKey(x => x.parId);
                parent.HasData(ParentReportInit);
            });
            modelBuilder.Entity<Permission>(permission =>
            {
                permission.ToTable("Permissions");
                permission.HasKey(x => x.perId);
            });
            modelBuilder.Entity<Rol>(rol =>
            {
                rol.ToTable("Roles");
                rol.HasKey(x => x.rolId);
                rol.HasData(RolInit);
            });
            modelBuilder.Entity<Tokens>(tokens => 
            {
                tokens.ToTable("Tokens");
                tokens.HasKey(x => x.tknId);
            });
        }
        public DbSet<ChildReport> ChildReports { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<ParentReport> ParentReports { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        //public DbSet<UserPermission> UserPermissions { get; set; }
    }
}
