using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dogs.Migrations
{
    /// <inheritdoc />
    public partial class addHistoryOfBreed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HistoryOfBreed",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HistoryOfBreed",
                table: "Dogs");
        }
    }
}
