using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "TopicsChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChangeUserId",
                table: "SectionsChanges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Sections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TopicsChanges_CreateUserId",
                table: "TopicsChanges",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CreateUserId",
                table: "Topics",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionsChanges_ChangeUserId",
                table: "SectionsChanges",
                column: "ChangeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CreateUserId",
                table: "Sections",
                column: "CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_AspNetUsers_CreateUserId",
                table: "Sections",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionsChanges_AspNetUsers_ChangeUserId",
                table: "SectionsChanges",
                column: "ChangeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_CreateUserId",
                table: "Topics",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_AspNetUsers_CreateUserId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionsChanges_AspNetUsers_ChangeUserId",
                table: "SectionsChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_CreateUserId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.DropIndex(
                name: "IX_TopicsChanges_CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.DropIndex(
                name: "IX_Topics_CreateUserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_SectionsChanges_ChangeUserId",
                table: "SectionsChanges");

            migrationBuilder.DropIndex(
                name: "IX_Sections_CreateUserId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "ChangeUserId",
                table: "SectionsChanges");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Sections");
        }
    }
}
