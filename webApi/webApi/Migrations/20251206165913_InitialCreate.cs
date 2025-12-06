using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Float = table.Column<float>(type: "real", nullable: false),
                    Mieszane = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Czas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dataczas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pusta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mieszane2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Boolean = table.Column<bool>(type: "bit", nullable: false),
                    DuzoMissingowInt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemLocations_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Boolean", "Czas", "Data", "Dataczas", "DuzoMissingowInt", "Float", "Int", "Mieszane", "Mieszane2", "Pusta" },
                values: new object[,]
                {
                    { 1, true, "10:10", "11-02-1980", "11-02-1980 13:13:31", null, 2.2f, 1, "ala", "1", null },
                    { 2, false, "10:10", null, null, null, 2.2f, 1, null, "1.1", null },
                    { 3, false, "10:10", "11-02-1980", "11-02-1980 13:13:31", null, 0f, 0, "kot", "x", null },
                    { 4, false, null, "11-02-1980", "11-02-1980 13:13:31", null, 2.2f, 0, "1", "10:10", null },
                    { 5, true, null, null, "11-02-1980 13:13:31", null, 2.2f, 1, "2", "12-01-2020 10:10", null },
                    { 6, false, "10:10", "11-02-1980", "11-02-1980 13:13:31", null, 2.2f, 1, "3", "12-12-2020", null },
                    { 7, false, "10:10", "11-02-1980", null, null, 0f, 1, "4", null, null },
                    { 8, true, "10:10", "11-02-1980", "11-02-1980 13:13:31", 1, 2.2f, 1, "5", "True", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocations_ItemId",
                table: "ItemLocations",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemLocations");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
