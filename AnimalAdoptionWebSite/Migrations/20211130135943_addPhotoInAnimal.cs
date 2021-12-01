using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionWebSite.Migrations
{
    public partial class addPhotoInAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PHOTO",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PHOTO",
                table: "Animals");
        }
    }
}
