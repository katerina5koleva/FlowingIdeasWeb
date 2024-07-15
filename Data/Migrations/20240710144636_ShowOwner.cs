using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApp.Data.Migrations
{
    public partial class ShowOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Ideas");

            migrationBuilder.AddColumn<bool>(
                name: "ShowOwner",
                table: "Ideas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a23a7ee8-beb5-4238-ad8a-88d54b3c3d29",
                column: "ConcurrencyStamp",
                value: "afe8f5b8-cc03-4f1d-bd91-9c5e2cf859b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a820ccf9-54ac-4047-b4b5-48dab0dc962b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "510b39f7-117e-42b7-955b-cd28bb0f73aa", "AQAAAAEAACcQAAAAEBTYiu5q+Ft2UVBt5FIfPKb5yfPj3VLYCcOWYLfRBYQUGcswQDbZS/lzz0aCRNqzrg==", "9c959ec8-ca15-47be-9850-1af1239fb191" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOwner",
                table: "Ideas");

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
    }
}
