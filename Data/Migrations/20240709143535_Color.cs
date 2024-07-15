using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApp.Data.Migrations
{
    public partial class Color : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "IdeaTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29",
                column: "ConcurrencyStamp",
                value: "0190064c-4d79-4217-8003-a860fb400dff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a820ccf9-54ac-4047-b4b5-48dab0dc962b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b3c3357-3f06-42d4-b9ef-fedf8e2d9401", "AQAAAAEAACcQAAAAENdHhdq9vQpBitk/+k7l+vaFYwI9QHDoRy/NxUIv+xt2JveeoY/pzM4AVsL7JM61oA==", "4b1f0e55-6552-41bc-9b46-fcb001ab012d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "IdeaTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29",
                column: "ConcurrencyStamp",
                value: "0f60a6b2-8467-4140-bbef-aae0175204e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a820ccf9-54ac-4047-b4b5-48dab0dc962b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e1baf6f-c4a6-4259-82b5-e528123ce79e", "AQAAAAEAACcQAAAAEL34Jsy9hj/LGOOmt+aLaehapUQDPmNv6LhimAGBausFiZGWqajC7RcYfmsa77Swhg==", "cdf32ad7-b5c1-4c56-a968-5b68b0bc71c0" });
        }
    }
}
