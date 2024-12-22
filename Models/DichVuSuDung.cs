namespace Service_PhongTro.Models
{
    public class DichVuSuDung
    {
        public int IDPhong { get; set; }
        public int IDDichVu { get; set; }
        public Phong phong { get; set; }
        public DichVu? dichVu { get; set; }
    }
}
