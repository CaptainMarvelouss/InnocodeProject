using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPT.BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "CommentsReply");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "CommentsReply",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
