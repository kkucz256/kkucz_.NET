using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAB2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    temp = table.Column<float>(type: "REAL", nullable: false),
                    feels_like = table.Column<float>(type: "REAL", nullable: false),
                    temp_min = table.Column<float>(type: "REAL", nullable: false),
                    temp_max = table.Column<float>(type: "REAL", nullable: false),
                    pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    humidity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Data_history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mainId = table.Column<int>(type: "INTEGER", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Data_history_Main_mainId",
                        column: x => x.mainId,
                        principalTable: "Main",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    icon = table.Column<string>(type: "TEXT", nullable: false),
                    DataId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.id);
                    table.ForeignKey(
                        name: "FK_Weather_Data_history_DataId",
                        column: x => x.DataId,
                        principalTable: "Data_history",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Data_history",
                columns: new[] { "Id", "mainId", "name" },
                values: new object[,]
                {
                    { 1, null, "Wrocław" },
                    { 2, null, "Wrocław" },
                    { 3, null, "Wrocław" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_history_mainId",
                table: "Data_history",
                column: "mainId");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_DataId",
                table: "Weather",
                column: "DataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Data_history");

            migrationBuilder.DropTable(
                name: "Main");
        }
    }
}
