using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskRequestApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Customers_CustomerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Tickets",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                newName: "IX_Tickets_customerId");

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevel",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedTicket",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClosedTicket",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompletedTicket",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenTicket",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Customers_customerId",
                table: "Tickets",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Customers_customerId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AssignedTicket",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClosedTicket",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CompletedTicket",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OpenTicket",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Tickets",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_customerId",
                table: "Tickets",
                newName: "IX_Tickets_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "DifficultyLevel",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Customers_CustomerId",
                table: "Tickets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
