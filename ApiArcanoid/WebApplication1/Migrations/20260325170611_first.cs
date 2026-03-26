using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BallSkins",
                columns: table => new
                {
                    id_BallSkin = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallSkins", x => x.id_BallSkin);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_User = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Coins = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_User);
                });

            migrationBuilder.CreateTable(
                name: "UserSkins",
                columns: table => new
                {
                    id_UserSkin = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    ballSkin_id = table.Column<int>(type: "integer", nullable: false),
                    isSelected = table.Column<bool>(type: "boolean", nullable: false),
                    Userid_User = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkins", x => x.id_UserSkin);
                    table.ForeignKey(
                        name: "FK_UserSkins_BallSkins_ballSkin_id",
                        column: x => x.ballSkin_id,
                        principalTable: "BallSkins",
                        principalColumn: "id_BallSkin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkins_Users_Userid_User",
                        column: x => x.Userid_User,
                        principalTable: "Users",
                        principalColumn: "id_User");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkins_ballSkin_id",
                table: "UserSkins",
                column: "ballSkin_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkins_Userid_User",
                table: "UserSkins",
                column: "Userid_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkins");

            migrationBuilder.DropTable(
                name: "BallSkins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
