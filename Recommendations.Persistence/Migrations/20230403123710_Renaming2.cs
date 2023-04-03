using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recommendations.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Renaming2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_DiscussionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionTag_Reviews_DiscussionsId",
                table: "DiscussionTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Reviews_DiscussionId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Reviews_DiscussionId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Categories_CategoryId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ThemeId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AuthorRate",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Discussions");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Themes");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Discussions",
                newName: "IX_Discussions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ThemeId",
                table: "Discussions",
                newName: "IX_Discussions_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_Id",
                table: "Discussions",
                newName: "IX_Discussions_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CategoryId",
                table: "Discussions",
                newName: "IX_Discussions_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Name",
                table: "Themes",
                newName: "IX_Themes_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Id",
                table: "Themes",
                newName: "IX_Themes_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discussions",
                table: "Discussions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Themes",
                table: "Themes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Discussions_DiscussionId",
                table: "Comments",
                column: "DiscussionId",
                principalTable: "Discussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_AspNetUsers_UserId",
                table: "Discussions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Categories_CategoryId",
                table: "Discussions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Themes_ThemeId",
                table: "Discussions",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionTag_Discussions_DiscussionsId",
                table: "DiscussionTag",
                column: "DiscussionsId",
                principalTable: "Discussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Discussions_DiscussionId",
                table: "Images",
                column: "DiscussionId",
                principalTable: "Discussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Discussions_DiscussionId",
                table: "Likes",
                column: "DiscussionId",
                principalTable: "Discussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Discussions_DiscussionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_AspNetUsers_UserId",
                table: "Discussions");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Categories_CategoryId",
                table: "Discussions");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Themes_ThemeId",
                table: "Discussions");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionTag_Discussions_DiscussionsId",
                table: "DiscussionTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Discussions_DiscussionId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Discussions_DiscussionId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Themes",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discussions",
                table: "Discussions");

            migrationBuilder.RenameTable(
                name: "Themes",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Discussions",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Themes_Name",
                table: "Products",
                newName: "IX_Products_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Themes_Id",
                table: "Products",
                newName: "IX_Products_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Discussions_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Discussions_ThemeId",
                table: "Reviews",
                newName: "IX_Reviews_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Discussions_Id",
                table: "Reviews",
                newName: "IX_Reviews_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Discussions_CategoryId",
                table: "Reviews",
                newName: "IX_Reviews_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorRate",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ThemeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Id",
                table: "Ratings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ThemeId",
                table: "Ratings",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_DiscussionId",
                table: "Comments",
                column: "DiscussionId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionTag_Reviews_DiscussionsId",
                table: "DiscussionTag",
                column: "DiscussionsId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Reviews_DiscussionId",
                table: "Images",
                column: "DiscussionId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Reviews_DiscussionId",
                table: "Likes",
                column: "DiscussionId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Categories_CategoryId",
                table: "Reviews",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ThemeId",
                table: "Reviews",
                column: "ThemeId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
