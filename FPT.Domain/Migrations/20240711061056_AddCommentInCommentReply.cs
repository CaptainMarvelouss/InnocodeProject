using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPT.BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentInCommentReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentsReply_Comments_CommentId",
                table: "CommentsReply");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "CommentsReply",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsReply_Comments_CommentId",
                table: "CommentsReply",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentsReply_Comments_CommentId",
                table: "CommentsReply");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "CommentsReply",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsReply_Comments_CommentId",
                table: "CommentsReply",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
