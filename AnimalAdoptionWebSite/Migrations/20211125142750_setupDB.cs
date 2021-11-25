using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionWebSite.Migrations
{
    public partial class setupDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ADMIN_ID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAMESURNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OCCUPATION = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ADMIN_ID);
                });

            migrationBuilder.CreateTable(
                name: "Kinds",
                columns: table => new
                {
                    KIND_ID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE_NAME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinds", x => x.KIND_ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MEMBER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAMESURNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AGE = table.Column<byte>(type: "tinyint", nullable: false),
                    PHONENUMBER = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ABOUT = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MEMBER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    ANIMAL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KIND_ID = table.Column<byte>(type: "tinyint", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GENUS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AGE = table.Column<byte>(type: "tinyint", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    STATUS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.ANIMAL_ID);
                    table.ForeignKey(
                        name: "FK_Animals_Kinds_KIND_ID",
                        column: x => x.KIND_ID,
                        principalTable: "Kinds",
                        principalColumn: "KIND_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    ADOPTION_ID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEMBER_ID = table.Column<int>(type: "int", nullable: false),
                    ANIMAL_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.ADOPTION_ID);
                    table.ForeignKey(
                        name: "FK_Adoptions_Animals_ANIMAL_ID",
                        column: x => x.ANIMAL_ID,
                        principalTable: "Animals",
                        principalColumn: "ANIMAL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptions_Members_MEMBER_ID",
                        column: x => x.MEMBER_ID,
                        principalTable: "Members",
                        principalColumn: "MEMBER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_ANIMAL_ID",
                table: "Adoptions",
                column: "ANIMAL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_MEMBER_ID",
                table: "Adoptions",
                column: "MEMBER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_KIND_ID",
                table: "Animals",
                column: "KIND_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Kinds");
        }
    }
}
