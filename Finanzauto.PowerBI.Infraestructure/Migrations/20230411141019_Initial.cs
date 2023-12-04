using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzauto.PowerBI.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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
                    CodigoMensaje = table.Column<int>(type: "int", nullable: false),
                    DescMensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.InsertData(
                table: "ParentReports",
                columns: new[] { "parId", "createDate", "createUser", "modifyDate", "modifyUser", "parDescription", "parIcon", "state" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6220), 4, null, null, "Reportes Estratégicos", "strategic", true },
                    { 2, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6223), 2140, null, null, "Reportes Tácticos", "tactical", true },
                    { 3, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6224), 2140, null, null, "Reportes Operacionales", "operative", true },
                    { 4, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6225), 2140, null, null, "Reportes Administrador", "administrador", true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "rolId", "createDate", "createUser", "modifyDate", "modifyUser", "rolDescription", "state" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6126), 1, null, null, "Administrador", true },
                    { 2, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6152), 1, null, null, "Operativo", true },
                    { 3, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6153), 1, null, null, "Estrategico", true },
                    { 4, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6154), 1, null, null, "Supervisor", true },
                    { 5, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6156), 1, null, null, "Default", true }
                });

            migrationBuilder.InsertData(
                table: "ChildReports",
                columns: new[] { "chId", "chiDescription", "chiUrl", "createDate", "createUser", "modifyDate", "modifyUser", "parId", "state" },
                values: new object[,]
                {
                    { 1, "Reporte Estratégico # 1", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ9", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6233), 2140, null, null, 1, true },
                    { 2, "Reporte Estratégico # 2 ", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ10", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6235), 2140, null, null, 1, true },
                    { 3, "Reporte Estratégico # 3", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ11", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6236), 2140, null, null, 1, true },
                    { 4, "Reporte Táctico # 1", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ12", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6238), 2140, null, null, 2, true },
                    { 5, "Reporte Táctico # 2", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ13", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6239), 2140, null, null, 2, true },
                    { 6, "Reporte Táctico # 3", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ14", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6242), 2140, null, null, 2, true },
                    { 7, "Reporte Operativo # 1", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ15\r\n", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6243), 2140, null, null, 3, true },
                    { 8, "Reporte Operativo # 2", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ16\r\n", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6244), 2140, null, null, 3, true },
                    { 9, "Reporte Táctico # 3", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ17\r\n", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6245), 2140, null, null, 3, true },
                    { 10, "Gestión de Permisos", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ18\r\n", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6247), 2140, null, null, 4, true },
                    { 11, "Gestión de Reportes", "https://app.powerbi.com/view?r=eyJrIjoiZjIwZmUxYWYtOTc0Zi00OTExLWEyNzAtZTIwYmQyNDAzNjg4IiwidCI6IjhlZGRjOTE5LTMxNzEtNDYwZC04NGE0LWIzMGFlNjVlMzdjMyJ19\r\n", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6248), 2140, null, null, 4, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "usrId", "createDate", "createUser", "modifyDate", "modifyUser", "rolId", "state", "usrDomainName", "usrEmail", "usrLastName", "usrName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6211), 1, null, null, 1, true, "efrain.guzman", "efrain.guzman@finanzauto.com.co", "Guzman", "Efrain" },
                    { 2, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6214), 1, null, null, 1, true, "hector.cruz", "hector.cruz@finanzauto.com.co", "Cruz", "Hector" },
                    { 3, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6215), 1, null, null, 1, true, "cristian.vargas", "cristian.vargas@finanzauto.com.co", "Vargas", "Cristian" },
                    { 4, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6217), 1, null, null, 1, true, "julian.bojaca", "julian.bojaca@finanzauto.com.co", "Bojaca", "Julian" }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "lgnId", "createDate", "createUser", "lgnConnectionTimes", "lgnIp", "lgnLastConnection", "modifyDate", "modifyUser", "state", "usrId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6252), 4, 10, "123.12.36.52", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6251), null, null, true, 1 },
                    { 2, new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6254), 4, 10, "123.12.36.2", new DateTime(2023, 4, 11, 9, 10, 18, 922, DateTimeKind.Local).AddTicks(6254), null, null, true, 1 }
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
