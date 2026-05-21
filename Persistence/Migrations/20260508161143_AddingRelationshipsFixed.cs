using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelationshipsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTags_Comments_CommentId",
                table: "ActivityTags");

            migrationBuilder.DropIndex(
                name: "IX_ActivityTags_CommentId",
                table: "ActivityTags");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "ActivityTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "ActivityTags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTags_CommentId",
                table: "ActivityTags",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTags_Comments_CommentId",
                table: "ActivityTags",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
