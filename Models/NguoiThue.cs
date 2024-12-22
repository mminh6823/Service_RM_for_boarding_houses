using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class NguoiThue
    {
        [Key]
        public int Id { get; set; }
        public string hoTen { get; set; }
        public int gioiTinh { get; set; }
        public string SDT { get; set; }
        public string queQuan { get; set; }
        public DateTime ngaySinh { get; set; }
        public string CMND_CCCD { get; set; }
        public string Email { get; set; }
        public string anhDaiDien { get; set; }
        public string matTruocCCCD { get; set; }
        public string matSauCMND { get; set; }

        public ICollection<ThuePhong> thuePhong { get; set; }
    }
}
