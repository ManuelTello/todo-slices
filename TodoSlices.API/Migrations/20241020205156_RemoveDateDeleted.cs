using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoSlices.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDateDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Workspaces");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "EntryRows");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "EntryColumns");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Boards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Workspaces",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "EntryRows",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "EntryColumns",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Boards",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
