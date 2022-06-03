using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class applicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 8888,
                column: "ConcurrencyStamp",
                value: "a9096a81-21b3-4190-baec-6e3fca526156");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "ec15b1f3-1d77-43d3-b45e-7ed7567dc0f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c74aa441-0e57-45ba-9113-3b31e5206aec", "AQAAAAEAACcQAAAAECjYk/0th1Biqq3X+NGb5ty4qUkAdCz4u3Pk7eLuiNvgRQAKZASk+SyIEW/Xj+PdIA==", "f61a9583-eb19-4a3c-a263-05795868a892" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 8888,
                column: "ConcurrencyStamp",
                value: "1ff64cd8-575d-49d0-b447-b71b704c3316");

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
    }
}
