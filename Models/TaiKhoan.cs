using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class TaiKhoan
    {
        [Key]
        public int Id { get; set; }
        public string? taiKhoan { get; set; }
        public string? matKhau { get; set; }
    }
}
