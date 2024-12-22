using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class ThongBao
    {
        [Key]
    public int Id { get; set; }
        public string tieuDe { get; set; }
        public DateTime ngayDang { get; set; }
        public string moTa { get; set; }
    }
}
