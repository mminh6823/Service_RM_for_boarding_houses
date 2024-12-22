using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class TaiKhoanNguoiDung
    {
        [Key]
        public int Id { get; set; }
        public string CMND_CCCD { get; set; }
        public string matKhau { get; set; }
    }
}
