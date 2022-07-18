using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropForeignKey(
                name: "FK_PersonCondition_Condition_LawyerConditionId",
                table: "PersonCondition");

            migrationBuilder.DropTable(
                name: "Condition");

         
 

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "LawyerCondition");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "LawyerCondition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonCondition_LawyerCondition_LawyerConditionId",
                table: "PersonCondition",
                column: "LawyerConditionId",
                principalTable: "LawyerCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonCondition_LawyerCondition_LawyerConditionId",
                table: "PersonCondition");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "LawyerCondition");

        

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "LawyerCondition",
                type: "bit",
                nullable: true);

        

            
 

            migrationBuilder.AddForeignKey(
                name: "FK_PersonCondition_Condition_LawyerConditionId",
                table: "PersonCondition",
                column: "LawyerConditionId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
