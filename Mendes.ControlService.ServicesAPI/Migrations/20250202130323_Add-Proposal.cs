using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mendes.ControlService.ManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Customers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PayingEntityId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposals_Customers_PayingEntityId",
                        column: x => x.PayingEntityId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_CustomerId",
                table: "Proposals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_PayingEntityId",
                table: "Proposals",
                column: "PayingEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
