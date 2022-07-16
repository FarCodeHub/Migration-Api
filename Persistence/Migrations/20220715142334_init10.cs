using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Lawyer_LawyerId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_LawyerId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LawyerId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "LawyerCondition");

            migrationBuilder.AddColumn<int>(
                name: "ConditionId",
                table: "LawyerCondition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Lawyer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonLawyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    LawyerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLawyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLawyer_Lawyer_LawyerId",
                        column: x => x.LawyerId,
                        principalTable: "Lawyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLawyer_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LawyerCondition_ConditionId",
                table: "LawyerCondition",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lawyer_PersonId",
                table: "Lawyer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLawyer_LawyerId",
                table: "PersonLawyer",
                column: "LawyerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLawyer_PersonId",
                table: "PersonLawyer",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lawyer_Persons_PersonId",
                table: "Lawyer",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerCondition_Condition_ConditionId",
                table: "LawyerCondition",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lawyer_Persons_PersonId",
                table: "Lawyer");

            migrationBuilder.DropForeignKey(
                name: "FK_LawyerCondition_Condition_ConditionId",
                table: "LawyerCondition");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "PersonLawyer");

            migrationBuilder.DropIndex(
                name: "IX_LawyerCondition_ConditionId",
                table: "LawyerCondition");

            migrationBuilder.DropIndex(
                name: "IX_Lawyer_PersonId",
                table: "Lawyer");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "LawyerCondition");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Lawyer");

            migrationBuilder.AddColumn<int>(
                name: "LawyerId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "LawyerCondition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LawyerId",
                table: "Persons",
                column: "LawyerId",
                unique: true,
                filter: "[LawyerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Lawyer_LawyerId",
                table: "Persons",
                column: "LawyerId",
                principalTable: "Lawyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
