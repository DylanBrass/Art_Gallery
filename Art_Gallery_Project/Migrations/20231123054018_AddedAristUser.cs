using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Art_Gallery_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddedAristUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d0e8eea-c6db-408a-8234-6e6691722d3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3e21226-0501-4a76-bcfc-de6bb0cb3368");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2a081a7-df82-4481-897d-3602375473fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea46261e-6749-43f8-a378-8561f3d56865");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Artist",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47120e7f-889b-4c16-8627-9fee437a9a49", "1", "Admin", "ADMIN" },
                    { "54c591c0-45dd-44ba-94cc-89e2741c6498", "2", "Artist", "ARTIST" },
                    { "98b02a34-d2ed-4f3b-b0fc-9d57192851be", "3", "Customer", "CUSTOMER" },
                    { "dee1ba4c-0236-48f7-bc97-0a8adcf88011", "4", "Gallery_Owner", "GALLERY_OWNER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_UserId",
                table: "Artist",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_AspNetUsers_UserId",
                table: "Artist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_AspNetUsers_UserId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_UserId",
                table: "Artist");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47120e7f-889b-4c16-8627-9fee437a9a49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54c591c0-45dd-44ba-94cc-89e2741c6498");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98b02a34-d2ed-4f3b-b0fc-9d57192851be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dee1ba4c-0236-48f7-bc97-0a8adcf88011");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Artist");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d0e8eea-c6db-408a-8234-6e6691722d3e", "2", "Artist", "ARTIST" },
                    { "a3e21226-0501-4a76-bcfc-de6bb0cb3368", "1", "Admin", "ADMIN" },
                    { "e2a081a7-df82-4481-897d-3602375473fb", "4", "Gallery_Owner", "GALLERY_OWNER" },
                    { "ea46261e-6749-43f8-a378-8561f3d56865", "3", "Customer", "CUSTOMER" }
                });
        }
    }
}
