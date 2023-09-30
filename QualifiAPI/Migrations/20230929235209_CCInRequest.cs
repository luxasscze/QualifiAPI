using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualifiAPI.Migrations
{
    /// <inheritdoc />
    public partial class CCInRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrequalificationRequestId",
                table: "CreditCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_PrequalificationRequestId",
                table: "CreditCards",
                column: "PrequalificationRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_Requests_PrequalificationRequestId",
                table: "CreditCards",
                column: "PrequalificationRequestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_Requests_PrequalificationRequestId",
                table: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_CreditCards_PrequalificationRequestId",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "PrequalificationRequestId",
                table: "CreditCards");
        }
    }
}
