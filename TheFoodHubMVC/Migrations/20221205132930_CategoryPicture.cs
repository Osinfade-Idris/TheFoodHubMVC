using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheFoodHubMVC.Migrations
{
    public partial class CategoryPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryPicture",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryPicture",
                table: "ProductCategories");
        }
    }
}
