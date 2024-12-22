using System.ComponentModel.DataAnnotations;

namespace Service_PhongTro.Models
{
    public class DichVu
    {
        [Key]
        public int Id { get; set; }
        public string tenDichVu { get; set; }
        public decimal giaDichVu { get; set; }

        public ICollection<DichVuSuDung> dichVuSuDung { get; set; }
    }
}
