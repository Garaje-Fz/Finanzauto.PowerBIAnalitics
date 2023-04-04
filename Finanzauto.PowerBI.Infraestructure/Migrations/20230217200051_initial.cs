using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzauto.PowerBI.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentReports",
                columns: table => new
                {
                    parId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentReports", x => x.parId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    rolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.rolId);
                });

            migrationBuilder.CreateTable(
                name: "ChildReports",
                columns: table => new
                {
                    chId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chiDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parId = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildReports", x => x.chId);
                    table.ForeignKey(
                        name: "FK_ChildReports_ParentReports_parId",
                        column: x => x.parId,
                        principalTable: "ParentReports",
                        principalColumn: "parId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    usrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usrLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usrEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usrDomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rolId = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.usrId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_rolId",
                        column: x => x.rolId,
                        principalTable: "Roles",
                        principalColumn: "rolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    lgnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lgnIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lgnConnectionTimes = table.Column<int>(type: "int", nullable: false),
                    lgnLastConnection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.lgnId);
                    table.ForeignKey(
                        name: "FK_Logins_Users_usrId",
                        column: x => x.usrId,
                        principalTable: "Users",
                        principalColumn: "usrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    logId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logPrintTimes = table.Column<int>(type: "int", nullable: false),
                    logLastConnection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    chId = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.logId);
                    table.ForeignKey(
                        name: "FK_Logs_ChildReports_chId",
                        column: x => x.chId,
                        principalTable: "ChildReports",
                        principalColumn: "chId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Users_usrId",
                        column: x => x.usrId,
                        principalTable: "Users",
                        principalColumn: "usrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    perId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    chilId = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.perId);
                    table.ForeignKey(
                        name: "FK_Permissions_ChildReports_chilId",
                        column: x => x.chilId,
                        principalTable: "ChildReports",
                        principalColumn: "chId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_usrId",
                        column: x => x.usrId,
                        principalTable: "Users",
                        principalColumn: "usrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    tknId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    tknToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tknRefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tknIsUsed = table.Column<bool>(type: "bit", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.tknId);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_usrId",
                        column: x => x.usrId,
                        principalTable: "Users",
                        principalColumn: "usrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildReports_parId",
                table: "ChildReports",
                column: "parId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_usrId",
                table: "Logins",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_chId",
                table: "Logs",
                column: "chId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_usrId",
                table: "Logs",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_chilId",
                table: "Permissions",
                column: "chilId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_usrId",
                table: "Tokens",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_rolId",
                table: "Users",
                column: "rolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "ChildReports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParentReports");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
