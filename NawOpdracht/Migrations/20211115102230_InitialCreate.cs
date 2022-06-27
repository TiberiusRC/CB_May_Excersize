using Microsoft.EntityFrameworkCore.Migrations;

namespace NawOpdracht.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Naw");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Naw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Naw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Naw",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Naw",
                table: "Address",
                columns: new[] { "Id", "HouseNumber", "StreetName", "Town" },
                values: new object[] { 1, "12a", "SomeStreet", "Amsterdam" });

            migrationBuilder.InsertData(
                schema: "Naw",
                table: "Address",
                columns: new[] { "Id", "HouseNumber", "StreetName", "Town" },
                values: new object[] { 2, "23", "SomeStreet2", "DenHaag" });

            migrationBuilder.InsertData(
                schema: "Naw",
                table: "Person",
                columns: new[] { "Id", "AddressId", "Age", "FirstName", "LastName" },
                values: new object[] { 2, 1, 68, "Truus", "Huus" });

            migrationBuilder.InsertData(
                schema: "Naw",
                table: "Person",
                columns: new[] { "Id", "AddressId", "Age", "FirstName", "LastName" },
                values: new object[] { 1, 2, 39, "Henk", "Van den Tillaard" });

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                schema: "Naw",
                table: "Person",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person",
                schema: "Naw");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Naw");
        }
    }
}
