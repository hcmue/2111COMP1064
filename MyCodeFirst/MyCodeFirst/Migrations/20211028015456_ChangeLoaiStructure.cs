using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCodeFirst.Migrations
{
    public partial class ChangeLoaiStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLoaiTruoc",
                table: "Loai",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loai_MaLoaiTruoc",
                table: "Loai",
                column: "MaLoaiTruoc");

            migrationBuilder.AddForeignKey(
                name: "FK_Loai_Loai_MaLoaiTruoc",
                table: "Loai",
                column: "MaLoaiTruoc",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loai_Loai_MaLoaiTruoc",
                table: "Loai");

            migrationBuilder.DropIndex(
                name: "IX_Loai_MaLoaiTruoc",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "MaLoaiTruoc",
                table: "Loai");
        }
    }
}
