using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonCondition_LawyerCondition_LawyerConditionId",
                table: "PersonCondition");

            migrationBuilder.DropIndex(
                name: "IX_Visas_PersonId",
                table: "Visas");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");

            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VisaExpirationDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "('0001-01-01T00:00:00.0000000')",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Persons",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LawyerCondition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false, comment: "1-new\r\n2-read\r\n3-answerd"),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketItem_Ticket",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visas_PersonId",
                table: "Visas",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketItem_TicketId",
                table: "TicketItem",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonCondition_LawyerCondition",
                table: "PersonCondition",
                column: "LawyerConditionId",
                principalTable: "LawyerCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonCondition_LawyerCondition",
                table: "PersonCondition");

            migrationBuilder.DropTable(
                name: "TicketItem");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Visas_PersonId",
                table: "Visas");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VisaExpirationDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "('0001-01-01T00:00:00.0000000')");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LawyerCondition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_PersonId",
                table: "Visas",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonCondition_LawyerCondition_LawyerConditionId",
                table: "PersonCondition",
                column: "LawyerConditionId",
                principalTable: "LawyerCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
