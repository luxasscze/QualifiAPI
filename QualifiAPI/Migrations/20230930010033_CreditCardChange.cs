using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualifiAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreditCardChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditScoreRequirement",
                table: "CreditCards");

            migrationBuilder.AddColumn<decimal>(
                name: "MinSalary",
                table: "CreditCards",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinSalary",
                table: "CreditCards");

            migrationBuilder.AddColumn<int>(
                name: "CreditScoreRequirement",
                table: "CreditCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
