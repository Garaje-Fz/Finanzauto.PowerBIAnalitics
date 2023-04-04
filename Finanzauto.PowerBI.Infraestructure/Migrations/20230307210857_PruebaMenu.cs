using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzauto.PowerBI.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class PruebaMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_chilId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions");

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    uspId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    perId = table.Column<int>(type: "int", nullable: false),
                    parId = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    modifyUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.uspId);
                    table.ForeignKey(
                        name: "FK_UserPermissions_ParentReports_parId",
                        column: x => x.parId,
                        principalTable: "ParentReports",
                        principalColumn: "parId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_perId",
                        column: x => x.perId,
                        principalTable: "Permissions",
                        principalColumn: "perId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_usrId",
                        column: x => x.usrId,
                        principalTable: "Users",
                        principalColumn: "usrId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_chilId",
                table: "Permissions",
                column: "chilId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_parId",
                table: "UserPermissions",
                column: "parId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_perId",
                table: "UserPermissions",
                column: "perId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_usrId",
                table: "UserPermissions",
                column: "usrId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_chilId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_chilId",
                table: "Permissions",
                column: "chilId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions",
                column: "usrId",
                unique: true);
        }
    }
}
