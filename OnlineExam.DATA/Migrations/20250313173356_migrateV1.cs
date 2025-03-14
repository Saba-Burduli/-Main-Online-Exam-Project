using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.DATA.Migrations
{
    /// <inheritdoc />
    public partial class migrateV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Saba", "Burduli" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Email",
                value: "s.burduli.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Dachi", "Skhirtladze" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Email",
                value: "d.skhirtladze@gmail.com");
        }
    }
}
