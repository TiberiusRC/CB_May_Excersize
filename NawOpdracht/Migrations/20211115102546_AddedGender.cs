using Microsoft.EntityFrameworkCore.Migrations;

namespace NawOpdracht.Migrations
{
    public partial class AddedGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "Naw",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Naw",
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "male");

            migrationBuilder.UpdateData(
                schema: "Naw",
                table: "Person",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: "female");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Naw",
                table: "Person");
        }
    }
}
