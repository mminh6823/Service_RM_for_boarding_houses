using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_PhongTro.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dayTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDayTro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    soLuongPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dayTro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dichVu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    giaDichVu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dichVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiPhong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoaiPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    soNguoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiPhong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nguoiThue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gioiTinh = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    queQuan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMND_CCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    anhDaiDien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matTruocCCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matSauCMND = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiThue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taiKhoan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    matKhau = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoanNguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMND_CCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoanNguoiDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "thongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tieuDe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ngayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IDLoaiPhong = table.Column<int>(type: "int", nullable: false),
                    conPhong = table.Column<bool>(type: "bit", nullable: false),
                    IDDayTro = table.Column<int>(type: "int", nullable: false),
                    SoNguoiDangO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phong_DayTro",
                        column: x => x.IDDayTro,
                        principalTable: "dayTro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Phong_LoaiPhong",
                        column: x => x.IDLoaiPhong,
                        principalTable: "loaiPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dichVuSuDung",
                columns: table => new
                {
                    IDPhong = table.Column<int>(type: "int", nullable: false),
                    IDDichVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dichVuSuDung", x => new { x.IDDichVu, x.IDPhong });
                    table.ForeignKey(
                        name: "FK_DichVuSuDung_DichVu",
                        column: x => x.IDDichVu,
                        principalTable: "dichVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DichVuSuDung_Phong",
                        column: x => x.IDPhong,
                        principalTable: "phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dienNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPhong = table.Column<int>(type: "int", nullable: false),
                    thoiGianHoaDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dienTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaDien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nuocTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaNuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dienNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DienNuoc_Phong",
                        column: x => x.IDPhong,
                        principalTable: "phong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "thuePhong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPhong = table.Column<int>(type: "int", nullable: false),
                    IDNguoiThue = table.Column<int>(type: "int", nullable: false),
                    ngayThue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tienCoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thuePhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThuePhong_NguoiThue",
                        column: x => x.IDNguoiThue,
                        principalTable: "nguoiThue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThuePhong_Phong",
                        column: x => x.IDPhong,
                        principalTable: "phong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hoaDon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDThuePhong = table.Column<int>(type: "int", nullable: false),
                    ngayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    soTienThanhToan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trangThai = table.Column<int>(type: "int", nullable: false),
                    CMND_CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loaiPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    giaPhong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dienTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaDien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nuocTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaNuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DSdichVuSuDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DSGiaDichVuSuDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThuePhong",
                        column: x => x.IDThuePhong,
                        principalTable: "thuePhong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dichVuSuDung_IDPhong",
                table: "dichVuSuDung",
                column: "IDPhong");

            migrationBuilder.CreateIndex(
                name: "IX_dienNuoc_IDPhong",
                table: "dienNuoc",
                column: "IDPhong");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDon_IDThuePhong",
                table: "hoaDon",
                column: "IDThuePhong");

            migrationBuilder.CreateIndex(
                name: "IX_phong_IDDayTro",
                table: "phong",
                column: "IDDayTro");

            migrationBuilder.CreateIndex(
                name: "IX_phong_IDLoaiPhong",
                table: "phong",
                column: "IDLoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_thuePhong_IDNguoiThue",
                table: "thuePhong",
                column: "IDNguoiThue");

            migrationBuilder.CreateIndex(
                name: "IX_thuePhong_IDPhong",
                table: "thuePhong",
                column: "IDPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "dichVuSuDung");

            migrationBuilder.DropTable(
                name: "dienNuoc");

            migrationBuilder.DropTable(
                name: "hoaDon");

            migrationBuilder.DropTable(
                name: "taiKhoan");

            migrationBuilder.DropTable(
                name: "taiKhoanNguoiDung");

            migrationBuilder.DropTable(
                name: "thongBao");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "dichVu");

            migrationBuilder.DropTable(
                name: "thuePhong");

            migrationBuilder.DropTable(
                name: "nguoiThue");

            migrationBuilder.DropTable(
                name: "phong");

            migrationBuilder.DropTable(
                name: "dayTro");

            migrationBuilder.DropTable(
                name: "loaiPhong");
        }
    }
}
