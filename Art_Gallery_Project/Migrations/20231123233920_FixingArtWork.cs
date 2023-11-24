using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Art_Gallery_Project.Migrations
{
    /// <inheritdoc />
    public partial class FixingArtWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4802d140-c85a-4c90-aacb-689a6ff52c06", "3", "Customer", "CUSTOMER" },
                    { "5c14e3c1-2bc7-4557-9dec-d1fa37a0d9a6", "2", "Artist", "ARTIST" },
                    { "95dbf420-86a5-44d1-bdba-285225f6fefb", "4", "Gallery_Owner", "GALLERY_OWNER" },
                    { "eec7722c-b95e-484b-a80d-7e4b0e9bab24", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4802d140-c85a-4c90-aacb-689a6ff52c06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c14e3c1-2bc7-4557-9dec-d1fa37a0d9a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95dbf420-86a5-44d1-bdba-285225f6fefb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eec7722c-b95e-484b-a80d-7e4b0e9bab24");

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
    }
}
