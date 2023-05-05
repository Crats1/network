using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFollowersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersLikesPosts_UserID",
                table: "UsersLikesPosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersLikesPosts",
                table: "UsersLikesPosts",
                columns: new[] { "UserID", "PostID" });

            migrationBuilder.CreateTable(
                name: "UserFollowers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    FollowerID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowers", x => new { x.UserID, x.FollowerID });
                    table.ForeignKey(
                        name: "FK_UserFollowers_AspNetUsers_FollowerID",
                        column: x => x.FollowerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFollowers_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_FollowerID",
                table: "UserFollowers",
                column: "FollowerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersLikesPosts",
                table: "UsersLikesPosts");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLikesPosts_UserID",
                table: "UsersLikesPosts",
                column: "UserID");
        }
    }
}
