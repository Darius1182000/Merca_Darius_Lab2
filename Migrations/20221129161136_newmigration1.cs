using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merca_Darius_Lab2.Migrations
{
    public partial class newmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "CityID",
               table: "Customer",
               type: "int",
               nullable: true);

                  migrationBuilder.CreateIndex(
                name: "IX_Customer_CityID",
                table: "Customer",
                column: "CityID");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
