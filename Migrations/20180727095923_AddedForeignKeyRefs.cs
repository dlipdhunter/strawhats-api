using Microsoft.EntityFrameworkCore.Migrations;

namespace strawhatsapi.Migrations
{
    public partial class AddedForeignKeyRefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrewName",
                table: "Pirates");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Pirates",
                newName: "PirateID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PirateCrews",
                newName: "PirateCrewID");

            migrationBuilder.AlterColumn<double>(
                name: "Bounty",
                table: "Pirates",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "PirateCrewID",
                table: "Pirates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pirates_PirateCrewID",
                table: "Pirates",
                column: "PirateCrewID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pirates_PirateCrews_PirateCrewID",
                table: "Pirates",
                column: "PirateCrewID",
                principalTable: "PirateCrews",
                principalColumn: "PirateCrewID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pirates_PirateCrews_PirateCrewID",
                table: "Pirates");

            migrationBuilder.DropIndex(
                name: "IX_Pirates_PirateCrewID",
                table: "Pirates");

            migrationBuilder.DropColumn(
                name: "PirateCrewID",
                table: "Pirates");

            migrationBuilder.RenameColumn(
                name: "PirateID",
                table: "Pirates",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PirateCrewID",
                table: "PirateCrews",
                newName: "ID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bounty",
                table: "Pirates",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "CrewName",
                table: "Pirates",
                nullable: true);
        }
    }
}
