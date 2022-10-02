using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoDockTestApp.Migrations
{
    public partial class PopulateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreationDate", "Status", "Title" },
                values: new object[] { 2L, new DateTime(2022, 10, 2, 20, 14, 13, 963, DateTimeKind.Local).AddTicks(6969), 2, "Составить и отправить СЗВ-М" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
