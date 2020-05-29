using Microsoft.EntityFrameworkCore.Migrations;

namespace quizManager.Migrations
{
    public partial class AddQuestionOrderToQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuestionOrder_QuestionId",
                table: "QuestionOrder");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOrder_QuestionId",
                table: "QuestionOrder",
                column: "QuestionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuestionOrder_QuestionId",
                table: "QuestionOrder");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOrder_QuestionId",
                table: "QuestionOrder",
                column: "QuestionId");
        }
    }
}
