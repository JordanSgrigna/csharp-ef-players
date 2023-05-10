using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkPlayers.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    player_surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    player_score = table.Column<int>(type: "int", nullable: false),
                    player_number_of_games_played = table.Column<int>(type: "int", nullable: false),
                    player_number_of_games_won = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
