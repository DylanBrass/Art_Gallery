using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Art_Gallery_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingArtistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18273e74-df0d-402b-bf9e-0a437957af4c", "4", "Gallery_Owner", "GALLERY_OWNER" },
                    { "85f7f81a-d69c-451e-98b3-595544fe9f3f", "1", "Admin", "ADMIN" },
                    { "9fcddc53-3dc7-4757-8779-fa76b8439b0d", "2", "Artist", "ARTIST" },
                    { "e4b5feb8-80f2-46ba-b081-e46b088916be", "3", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18273e74-df0d-402b-bf9e-0a437957af4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f7f81a-d69c-451e-98b3-595544fe9f3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fcddc53-3dc7-4757-8779-fa76b8439b0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4b5feb8-80f2-46ba-b081-e46b088916be");

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
        }
    }
}
