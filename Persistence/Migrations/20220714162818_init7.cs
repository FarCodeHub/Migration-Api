using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LawyerId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lawyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LawyerCondition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LawyerId = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawyerCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawyerCondition_Lawyer_LawyerId",
                        column: x => x.LawyerId,
                        principalTable: "Lawyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LawyerId",
                table: "Persons",
                column: "LawyerId",
                unique: true,
                filter: "[LawyerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LawyerCondition_LawyerId",
                table: "LawyerCondition",
                column: "LawyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Lawyer_LawyerId",
                table: "Persons",
                column: "LawyerId",
                principalTable: "Lawyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Lawyer_LawyerId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "LawyerCondition");

            migrationBuilder.DropTable(
                name: "Lawyer");

            migrationBuilder.DropIndex(
                name: "IX_Persons_LawyerId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LawyerId",
                table: "Persons");
        }
    }
}
