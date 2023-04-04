﻿// <auto-generated />
using System;
using Finanzauto.PowerBI.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finanzauto.PowerBI.Infraestructure.Migrations
{
    [DbContext(typeof(PowerBIDbContext))]
    [Migration("20230307210857_PruebaMenu")]
    partial class PruebaMenu
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.ChildReport", b =>
                {
                    b.Property<int>("chId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("chId"));

                    b.Property<string>("chiDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chiUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<int>("parId")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("chId");

                    b.HasIndex("parId");

                    b.ToTable("ChildReports");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Log", b =>
                {
                    b.Property<int>("logId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("logId"));

                    b.Property<int>("chId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("logLastConnection")
                        .HasColumnType("datetime2");

                    b.Property<int>("logPrintTimes")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("usrId")
                        .HasColumnType("int");

                    b.HasKey("logId");

                    b.HasIndex("chId");

                    b.HasIndex("usrId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Login", b =>
                {
                    b.Property<int>("lgnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lgnId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<int>("lgnConnectionTimes")
                        .HasColumnType("int");

                    b.Property<string>("lgnIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lgnLastConnection")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("usrId")
                        .HasColumnType("int");

                    b.HasKey("lgnId");

                    b.HasIndex("usrId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.ParentReport", b =>
                {
                    b.Property<int>("parId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("parId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<string>("parDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("parId");

                    b.ToTable("ParentReports");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Permission", b =>
                {
                    b.Property<int>("perId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("perId"));

                    b.Property<int>("chilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("usrId")
                        .HasColumnType("int");

                    b.HasKey("perId");

                    b.HasIndex("chilId")
                        .IsUnique();

                    b.HasIndex("usrId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Rol", b =>
                {
                    b.Property<int>("rolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("rolId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<string>("rolDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("rolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Tokens", b =>
                {
                    b.Property<int>("tknId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tknId"));

                    b.Property<DateTime>("ExpirateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<bool>("tknIsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("tknRefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tknToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usrId")
                        .HasColumnType("int");

                    b.HasKey("tknId");

                    b.HasIndex("usrId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.User", b =>
                {
                    b.Property<int>("usrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("usrId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<int>("rolId")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<string>("usrDomainName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("usrId");

                    b.HasIndex("rolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.UserPermission", b =>
                {
                    b.Property<int>("uspId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("uspId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("createUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifyUser")
                        .HasColumnType("int");

                    b.Property<int>("parId")
                        .HasColumnType("int");

                    b.Property<int>("perId")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("usrId")
                        .HasColumnType("int");

                    b.HasKey("uspId");

                    b.HasIndex("parId");

                    b.HasIndex("perId");

                    b.HasIndex("usrId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.ChildReport", b =>
                {
                    b.HasOne("Finanzauto.PowerBI.Domain.ParentReport", "ParentReport")
                        .WithMany("ChildReports")
                        .HasForeignKey("parId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentReport");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Log", b =>
                {
                    b.HasOne("Finanzauto.PowerBI.Domain.ChildReport", "ChildReport")
                        .WithMany()
                        .HasForeignKey("chId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finanzauto.PowerBI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("usrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChildReport");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Login", b =>
                {
                    b.HasOne("Finanzauto.PowerBI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("usrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Permission", b =>
                {
                    b.HasOne("Finanzauto.PowerBI.Domain.ChildReport", "ChildReport")
                        .WithOne("Permission")
                        .HasForeignKey("Finanzauto.PowerBI.Domain.Permission", "chilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finanzauto.PowerBI.Domain.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("usrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChildReport");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.Tokens", b =>
                {
                    b.HasOne("Finanzauto.PowerBI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("usrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.User", b =>
                {
                    b.HasOne("Finanzauto.PowerBI.Domain.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("rolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.UserPermission", b =>
                {
                    b.HasOne("Finanzauto.PowerBI.Domain.ParentReport", "ParentReport")
                        .WithMany()
                        .HasForeignKey("parId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finanzauto.PowerBI.Domain.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("perId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finanzauto.PowerBI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("usrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentReport");

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.ChildReport", b =>
                {
                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.ParentReport", b =>
                {
                    b.Navigation("ChildReports");
                });

            modelBuilder.Entity("Finanzauto.PowerBI.Domain.User", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
