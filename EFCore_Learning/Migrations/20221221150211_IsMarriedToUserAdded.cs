using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreLearning.Migrations
{
    /// <inheritdoc />
    public partial class IsMarriedToUserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isMarried",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMarried",
                table: "Users");
        }
    }
}
