using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTheWay.Web.Ui.Migrations
{
    public partial class ShippingContainers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingContainer",
                table: "ShippingContainer");

            migrationBuilder.RenameTable(
                name: "ShippingContainer",
                newName: "ShippingContainers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingContainers",
                table: "ShippingContainers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingContainers",
                table: "ShippingContainers");

            migrationBuilder.RenameTable(
                name: "ShippingContainers",
                newName: "ShippingContainer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingContainer",
                table: "ShippingContainer",
                column: "Id");
        }
    }
}
