using Microsoft.EntityFrameworkCore.Migrations;

namespace Guessing_Game.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Liverpool", "Joe", "700-309-341" },
                    { 2, "Stockholm", "Josef", "763-385-323" },
                    { 3, "Warszawa", "Gilbert", "774-375-333" },
                    { 4, "Barcelona", "Brad", "775-346-312" },
                    { 5, "Los Angeles", "Luka", "775-314-347" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
