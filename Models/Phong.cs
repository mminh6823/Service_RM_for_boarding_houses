using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class Phong
    {
        [Key]
        public int Id { get; set; }
        public string? tenPhong { get; set; }
        public int IDLoaiPhong { get; set; }
        public bool? conPhong { get; set; }
        public int IDDayTro { get; set; }
        public int SoNguoiDangO { get; set; }
        public LoaiPhong loaiPhong { get; set; }
        public DayTro dayTro { get; set; }
        public ICollection<DienNuoc> dienNuoc { get; set; }

        public ICollection<ThuePhong> thuePhong { get; set; }
        public ICollection<DichVuSuDung> dichVuSuDung { get; set; }
    }
}
