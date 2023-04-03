using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recommendations.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Renaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_ReviewId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Reviews_ReviewId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Reviews_ReviewId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "ReviewTag");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Reviews",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                newName: "IX_Reviews_ThemeId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Ratings",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                newName: "IX_Ratings_ThemeId");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Likes",
                newName: "DiscussionId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ReviewId",
                table: "Likes",
                newName: "IX_Likes_DiscussionId");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Images",
                newName: "DiscussionId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ReviewId",
                table: "Images",
                newName: "IX_Images_DiscussionId");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Comments",
                newName: "DiscussionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                newName: "IX_Comments_DiscussionId");

            migrationBuilder.CreateTable(
                name: "DiscussionTag",
                columns: table => new
                {
                    DiscussionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionTag", x => new { x.DiscussionsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_DiscussionTag_Reviews_DiscussionsId",
                        column: x => x.DiscussionsId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussionTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionTag_TagsId",
                table: "DiscussionTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_DiscussionId",
                table: "Comments",
                column: "DiscussionId",
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
                name: "FK_Ratings_Products_ThemeId",
                table: "Ratings",
                column: "ThemeId",
                principalTable: "Products",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_DiscussionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Reviews_DiscussionId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Reviews_DiscussionId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Products_ThemeId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ThemeId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "DiscussionTag");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Reviews",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ThemeId",
                table: "Reviews",
                newName: "IX_Reviews_ProductId");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Ratings",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ThemeId",
                table: "Ratings",
                newName: "IX_Ratings_ProductId");

            migrationBuilder.RenameColumn(
                name: "DiscussionId",
                table: "Likes",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_DiscussionId",
                table: "Likes",
                newName: "IX_Likes_ReviewId");

            migrationBuilder.RenameColumn(
                name: "DiscussionId",
                table: "Images",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_DiscussionId",
                table: "Images",
                newName: "IX_Images_ReviewId");

            migrationBuilder.RenameColumn(
                name: "DiscussionId",
                table: "Comments",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_DiscussionId",
                table: "Comments",
                newName: "IX_Comments_ReviewId");

            migrationBuilder.CreateTable(
                name: "ReviewTag",
                columns: table => new
                {
                    ReviewsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewTag", x => new { x.ReviewsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ReviewTag_Reviews_ReviewsId",
                        column: x => x.ReviewsId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTag_TagsId",
                table: "ReviewTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_ReviewId",
                table: "Comments",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Reviews_ReviewId",
                table: "Images",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Reviews_ReviewId",
                table: "Likes",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
