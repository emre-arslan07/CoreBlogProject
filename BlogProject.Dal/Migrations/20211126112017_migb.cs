using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Dal.Migrations
{
    public partial class migb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogSattus",
                table: "Blogs",
                newName: "BlogStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogStatus",
                table: "Blogs",
                newName: "BlogSattus");
        }
    }
}
