using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyLamNghiep.Migrations
{
    /// <inheritdoc />
    public partial class updateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChuongId",
                table: "DieuKhoans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChuongId",
                table: "DieuKhoans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
