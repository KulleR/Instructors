using Microsoft.EntityFrameworkCore.Migrations;

namespace Instructors.WebApi.Data.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 1, "Michelangelo", "Buonarroti", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 2, "Leonardo", "da Vinci", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 3, "Vandinelli", "Bartolommeo", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 4, "Lorenzo", "Ghiberti", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 5, "Benvenuto", "Cellini", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 6, "Bernando", "Rossellino", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 7, "Guido", "Mazzoni", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 8, "Pietro", "Torrigiano", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 9, "Diego", "Siloe", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 10, "Matteo", "Civitali", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 11, "Viet", "Stoss", "" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 12, "Alessandro", "Vittoria", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
