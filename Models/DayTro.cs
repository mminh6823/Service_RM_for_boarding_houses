using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class DayTro
    {
        [Key]
        public int Id { get; set; }
        public string? tenDayTro { get; set; }
        public int? soLuongPhong { get; set; }

        public ICollection<Phong> phong { get; set; }
    }
}
