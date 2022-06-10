using Microsoft.EntityFrameworkCore.Migrations;

namespace Guessing_Game.Migrations
{
    public partial class addedrolesandadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "663edd18-0453-47c4-b2c9-927f467197aa", "5c511ec5-02e7-47c1-94cb-cc6f1c0d05f3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9ec0b29-33cb-4b23-afb3-b60f6d7db532", "f86c7f89-97fd-4833-917f-77471b872860", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f8003ee7-281e-4381-bd26-78102d02f103", 0, "12.12.2000", "35034f16-9419-4af5-bcff-871a087af818", "admin@test.com", false, "Admin", "System", false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEAhobbIPM6Anc7aWjKXbANSSLdo1Fdv82AVckWuoEzS1GFEpd51Bm1UqWLO4epEwCg==", null, false, "5e734910-8102-4fdb-a65c-a901b4dedc50", false, "admin@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f8003ee7-281e-4381-bd26-78102d02f103", "663edd18-0453-47c4-b2c9-927f467197aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9ec0b29-33cb-4b23-afb3-b60f6d7db532");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f8003ee7-281e-4381-bd26-78102d02f103", "663edd18-0453-47c4-b2c9-927f467197aa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "663edd18-0453-47c4-b2c9-927f467197aa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8003ee7-281e-4381-bd26-78102d02f103");
        }
    }
}
