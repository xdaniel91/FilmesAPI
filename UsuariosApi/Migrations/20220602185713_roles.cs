using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 8888,
                column: "ConcurrencyStamp",
                value: "33a16b0e-9847-4917-b0bf-c621cab568b5");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 8888,
                column: "ConcurrencyStamp",
                value: "1975e675-4374-4ed9-8b12-82c515eb2f5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "1f3bb1e7-eb70-4c58-86b7-94df74b52531");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32f6bdef-a0e4-46af-989c-4e1cf48ac61c", "AQAAAAEAACcQAAAAED/cQjbblzsM+owt0e5rE2EI7oAi59kR+PyulSWo0MFQhSNHv97+SAoM7ZcOiqKNiA==", "a8cbe31c-41b8-48b8-9d2a-6e854c2109fc" });
        }
    }
}
