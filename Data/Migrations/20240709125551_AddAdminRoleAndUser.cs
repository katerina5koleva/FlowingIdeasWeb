using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApp.Data.Migrations
{
    public partial class AddAdminRoleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29", "d0565ee8-e83f-4e72-8510-f582d8f9abf9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a820ccf9-54ac-4047-b4b5-48dab0dc962b", 0, "18d92bb9-14f8-439a-8b8b-f18310610001", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEdN500PaSoIwzbnkQY8Ux0556dBpC0yafHBFcB76fEcZa+Tde3wRMyajCQ7iEx3XQ==", null, false, "7203743c-9b18-4d04-9f49-5671c443de38", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29", "a820ccf9-54ac-4047-b4b5-48dab0dc962b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29", "a820ccf9-54ac-4047-b4b5-48dab0dc962b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a820ccf9-54ac-4047-b4b5-48dab0dc962b");
        }
    }
}
