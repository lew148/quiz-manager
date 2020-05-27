using Microsoft.EntityFrameworkCore.Migrations;
using quizManager.Data.Models;
using static BCrypt.Net.BCrypt;

namespace quizManager.Migrations
{
    // Seeding db with users
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var columns = new[] { "Username", "Password", "Permission" };

            var values = new object[,]
            {
                { "edit", HashPassword("edit123"), (int)Permission.Edit },
                { "view", HashPassword("view123"), (int)Permission.View },
                { "restricted", HashPassword("restricted123"), (int)Permission.Restricted }
            };

            migrationBuilder.InsertData("Users", columns, values);
        }

        
        // no down
        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
