using Service_PhongTro.Models;

namespace Service_PhongTro.DTOs
{
    public class HoaDonDTO
    {
        public int Id { get; set; }
        public DateTime ngayThanhToan { get; set; }
        public decimal soTienThanhToan { get; set; }
        public int trangThai { get; set; }
        public string CMND_CCCD { get; set; }
        public string tenPhong { get; set; }
        public string loaiPhong { get; set; }
        public decimal giaPhong { get; set; }
        public int dienTieuThu { get; set; }
        public decimal giaDien { get; set; }
        public int nuocTieuThu { get; set; }
        public decimal giaNuoc { get; set; }
        public string DSdichVuSuDung { get; set; }
        public string DSGiaDichVuSuDung { get; set; }
        public ThuePhongDTO thuePhong { get; set; }

    }
}
