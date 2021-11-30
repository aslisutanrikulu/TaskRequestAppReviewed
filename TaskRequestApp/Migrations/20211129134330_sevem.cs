using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskRequestApp.Migrations
{
    public partial class sevem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Tickets_ticketId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ticketId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MaterialityLevel",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ticketId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevel",
                table: "Tickets",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "CompletedDate",
                table: "Tickets",
                newName: "ReviewDate");

            migrationBuilder.RenameColumn(
                name: "ClosedDate",
                table: "Tickets",
                newName: "CompleteDate");

            migrationBuilder.RenameColumn(
                name: "AssignedDate",
                table: "Tickets",
                newName: "CloseDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssigneDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "employeeId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_employeeId",
                table: "Tickets",
                column: "employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_employeeId",
                table: "Tickets",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_employeeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_employeeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AssigneDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ReviewDate",
                table: "Tickets",
                newName: "CompletedDate");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Tickets",
                newName: "DifficultyLevel");

            migrationBuilder.RenameColumn(
                name: "CompleteDate",
                table: "Tickets",
                newName: "ClosedDate");

            migrationBuilder.RenameColumn(
                name: "CloseDate",
                table: "Tickets",
                newName: "AssignedDate");

            migrationBuilder.AddColumn<string>(
                name: "MaterialityLevel",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ticketId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ticketId",
                table: "Employees",
                column: "ticketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Tickets_ticketId",
                table: "Employees",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
