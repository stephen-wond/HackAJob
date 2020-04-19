using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTAuth.Migrations
{
    public partial class JwtAuthDataPhonebookContextWithSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "Steve", "Wond", "09876543210" });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "EmailAddress", "Password", "Username" },
                values: new object[] { 1, "Steve@Steve.com", "123", "Steve" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
