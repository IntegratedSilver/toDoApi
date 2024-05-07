using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DayName = table.Column<string>(type: "TEXT", nullable: true),
                    objective1 = table.Column<string>(type: "TEXT", nullable: true),
                    Objective2 = table.Column<string>(type: "TEXT", nullable: true),
                    Objective3 = table.Column<string>(type: "TEXT", nullable: true),
                    Objective4 = table.Column<string>(type: "TEXT", nullable: true),
                    Objective5 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
