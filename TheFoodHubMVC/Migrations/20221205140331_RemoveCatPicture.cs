using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheFoodHubMVC.Migrations
{
    public partial class RemoveCatPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryPicture",
                table: "ProductCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryPicture",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
