using Service_PhongTro.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service_PhongTro.DTOs
{
    public class HoaDonDTO
    {
        public int Id { get; set; }
        public int IDThuePhong { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public decimal? TongTienThanhToan { get; set; }
    }
}
