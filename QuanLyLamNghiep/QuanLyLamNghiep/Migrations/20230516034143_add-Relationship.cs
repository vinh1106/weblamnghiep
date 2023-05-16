using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyLamNghiep.Migrations
{
    /// <inheritdoc />
    public partial class addRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChuongMucId",
                table: "DieuKhoans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DieuKhoans_ChuongMucId",
                table: "DieuKhoans",
                column: "ChuongMucId");

            migrationBuilder.AddForeignKey(
                name: "FK_DieuKhoans_ChuongMucs_ChuongMucId",
                table: "DieuKhoans",
                column: "ChuongMucId",
                principalTable: "ChuongMucs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieuKhoans_ChuongMucs_ChuongMucId",
                table: "DieuKhoans");

            migrationBuilder.DropIndex(
                name: "IX_DieuKhoans_ChuongMucId",
                table: "DieuKhoans");

            migrationBuilder.DropColumn(
                name: "ChuongMucId",
                table: "DieuKhoans");
        }
    }
}
