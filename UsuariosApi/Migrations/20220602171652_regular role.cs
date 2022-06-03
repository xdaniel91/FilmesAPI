using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class regularrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999);

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 99999, 0, "32f6bdef-a0e4-46af-989c-4e1cf48ac61c", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAED/cQjbblzsM+owt0e5rE2EI7oAi59kR+PyulSWo0MFQhSNHv97+SAoM7ZcOiqKNiA==", null, false, "a8cbe31c-41b8-48b8-9d2a-6e854c2109fc", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 8888,
                column: "ConcurrencyStamp",
                value: "0fd38908-cc55-4fa0-bb6c-355c9e06e01b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "e80faf4b-d116-4a4d-abbc-d06333d29106");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 9999, 0, "ff943581-e096-47d9-8e39-814c37f6146c", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAECrB6Isn7uvf4t0aiEDzmv7Q2lfnT9ywhGHn6KkO+yI3SduKsK5PHJ7jGP7M8oEyJw==", null, false, "d6f7bdcd-cf3d-4de2-afb6-844bf74ca7ac", false, "admin" });
        }
    }
}
