using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualifiAPI.Migrations
{
    /// <inheritdoc />
    public partial class Ress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditCardIdsJson",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardIdsJson",
                table: "Requests");
        }
    }
}
