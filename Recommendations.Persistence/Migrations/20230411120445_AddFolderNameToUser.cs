using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recommendations.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFolderNameToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FolderName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderName",
                table: "AspNetUsers");
        }
    }
}
