using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dogs.Migrations
{
    /// <inheritdoc />
    public partial class addEditForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogTag_Dogs_DogId",
                table: "DogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_DogTag_Tag_TagId",
                table: "DogTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogTag",
                table: "DogTag");

            migrationBuilder.RenameTable(
                name: "DogTag",
                newName: "DogTags");

            migrationBuilder.RenameIndex(
                name: "IX_DogTag_TagId",
                table: "DogTags",
                newName: "IX_DogTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_DogTag_DogId",
                table: "DogTags",
                newName: "IX_DogTags_DogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogTags",
                table: "DogTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DogTags_Dogs_DogId",
                table: "DogTags",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DogTags_Tag_TagId",
                table: "DogTags",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogTags_Dogs_DogId",
                table: "DogTags");

            migrationBuilder.DropForeignKey(
                name: "FK_DogTags_Tag_TagId",
                table: "DogTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogTags",
                table: "DogTags");

            migrationBuilder.RenameTable(
                name: "DogTags",
                newName: "DogTag");

            migrationBuilder.RenameIndex(
                name: "IX_DogTags_TagId",
                table: "DogTag",
                newName: "IX_DogTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_DogTags_DogId",
                table: "DogTag",
                newName: "IX_DogTag_DogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogTag",
                table: "DogTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DogTag_Dogs_DogId",
                table: "DogTag",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DogTag_Tag_TagId",
                table: "DogTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
