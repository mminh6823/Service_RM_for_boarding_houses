using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service_PhongTro.Models
{
    public class HoaDon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("ThuePhong")]
        public int IDThuePhong { get; set; }
        [Required]
        public DateTime NgayThanhToan { get; set; }
        [Required]
        [Column(TypeName = "decimal(15, 2)")]
        public decimal TongTienThanhToan { get; set; }
        [Required]
        public int TrangThai { get; set; }

        public ThuePhong ThuePhong { get; set; }
        public string GhiChu { get; set; }
    }
}
