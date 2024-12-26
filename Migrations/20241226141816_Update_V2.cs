using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_PhongTro.Migrations
{
    /// <inheritdoc />
    public partial class Update_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CMND_CCCD",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "DSGiaDichVuSuDung",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "dienTieuThu",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "giaDien",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "giaNuoc",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "giaPhong",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "loaiPhong",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "nuocTieuThu",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "soTienThanhToan",
                table: "hoaDon");

            migrationBuilder.DropColumn(
                name: "tenPhong",
                table: "hoaDon");

            migrationBuilder.RenameColumn(
                name: "trangThai",
                table: "hoaDon",
                newName: "TrangThai");

            migrationBuilder.RenameColumn(
                name: "ngayThanhToan",
                table: "hoaDon",
                newName: "NgayThanhToan");

            migrationBuilder.RenameColumn(
                name: "DSdichVuSuDung",
                table: "hoaDon",
                newName: "GhiChu");

            migrationBuilder.AddColumn<decimal>(
                name: "TongTienThanhToan",
                table: "hoaDon",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongTienThanhToan",
                table: "hoaDon");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "hoaDon",
                newName: "trangThai");

            migrationBuilder.RenameColumn(
                name: "NgayThanhToan",
                table: "hoaDon",
                newName: "ngayThanhToan");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "hoaDon",
                newName: "DSdichVuSuDung");

            migrationBuilder.AddColumn<string>(
                name: "CMND_CCCD",
                table: "hoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DSGiaDichVuSuDung",
                table: "hoaDon",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "dienTieuThu",
                table: "hoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "giaDien",
                table: "hoaDon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "giaNuoc",
                table: "hoaDon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "giaPhong",
                table: "hoaDon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "loaiPhong",
                table: "hoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "nuocTieuThu",
                table: "hoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "soTienThanhToan",
                table: "hoaDon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "tenPhong",
                table: "hoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
