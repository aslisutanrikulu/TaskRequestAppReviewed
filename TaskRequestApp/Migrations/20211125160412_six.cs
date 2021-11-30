using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskRequestApp.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedTicket",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "OpenTicket",
                table: "Tickets",
                newName: "OpenDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Tickets",
                newName: "CompletedDate");

            migrationBuilder.RenameColumn(
                name: "CompletedTicket",
                table: "Tickets",
                newName: "ClosedDate");

            migrationBuilder.RenameColumn(
                name: "ClosedTicket",
                table: "Tickets",
                newName: "AssignedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenDate",
                table: "Tickets",
                newName: "OpenTicket");

            migrationBuilder.RenameColumn(
                name: "CompletedDate",
                table: "Tickets",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ClosedDate",
                table: "Tickets",
                newName: "CompletedTicket");

            migrationBuilder.RenameColumn(
                name: "AssignedDate",
                table: "Tickets",
                newName: "ClosedTicket");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedTicket",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
