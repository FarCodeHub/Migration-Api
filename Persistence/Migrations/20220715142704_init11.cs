using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lawyer_Persons_PersonId",
                table: "Lawyer");

            migrationBuilder.DropIndex(
                name: "IX_Lawyer_PersonId",
                table: "Lawyer");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Lawyer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Lawyer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lawyer_PersonId",
                table: "Lawyer",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lawyer_Persons_PersonId",
                table: "Lawyer",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
