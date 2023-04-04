using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzauto.PowerBI.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Local : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions",
                column: "usrId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_usrId",
                table: "Permissions",
                column: "usrId");
        }
    }
}
