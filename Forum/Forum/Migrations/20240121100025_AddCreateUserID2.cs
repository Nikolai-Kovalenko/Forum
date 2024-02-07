using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateUserID2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicComments_AspNetUsers_CreateUserId",
                table: "TopicComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "TopicsChanges",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "TopicComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicComments_AspNetUsers_CreateUserId",
                table: "TopicComments",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicComments_AspNetUsers_CreateUserId",
                table: "TopicComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "TopicsChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "TopicComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicComments_AspNetUsers_CreateUserId",
                table: "TopicComments",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
