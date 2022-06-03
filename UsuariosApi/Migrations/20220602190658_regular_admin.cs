using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class regular_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 8888,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "1ff64cd8-575d-49d0-b447-b71b704c3316", "regular" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "62ec11f6-bd49-4489-aa8e-31747c214452");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a3274b4-51db-479b-8f3c-0bdb2b9f798c", "AQAAAAEAACcQAAAAEMjr3XqkVVimyIaxpN5NEOkzteIWXqoUaEGl3Ub9ZvBVZ0V6L1fOXlWQ5Ven6Kk9Aw==", "8eafd0f8-1900-4b01-9d5f-a1310dcf2827" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 8888,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "33a16b0e-9847-4917-b0bf-c621cab568b5", "reular" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "91e3ca84-68bf-4042-ad20-7ff2c7025712");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb57dd90-537c-4553-b198-6f2ecbca13ae", "AQAAAAEAACcQAAAAEB+mumYe3dorRv1T+Ngv5TkDedCmDdPbovbJ6mxvqJXjITCZLLogNd+lgRdDBmXkKA==", "5f87bf4f-984c-47d2-87f9-6824ad2bc421" });
        }
    }
}
