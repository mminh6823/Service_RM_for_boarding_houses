using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class LoaiPhong
    {
        [Key]
        public int Id { get; set; }
        public string? tenLoaiPhong { get; set; }
        public decimal? gia { get; set; }
        public int soNguoi { get; set; }
        public ICollection<Phong> phong { get; set; }
    }
}


