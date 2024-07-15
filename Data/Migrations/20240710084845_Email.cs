using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApp.Data.Migrations
{
    public partial class Email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Ideas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29",
                column: "ConcurrencyStamp",
                value: "2b0592ab-05d8-456e-9e6b-4f99be0d2673");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a820ccf9-54ac-4047-b4b5-48dab0dc962b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98e38cdc-8b2f-46b5-bd59-0db13a38c1f7", "AQAAAAEAACcQAAAAEElD1PkovbqnWPXL65Wxsv0LlrQTG7WyRvuZkNak+TrxPVo6wXDntMC4wCMKgYYj6w==", "feabd197-383b-472c-9b8b-dab33baa71f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Ideas");

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
    }
}
