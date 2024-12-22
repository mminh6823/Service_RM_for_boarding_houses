namespace Service_PhongTro.DTOs
{
    public class DichVuSuDungDTO
    {
        public int IDPhong { get; set; }
        public int IDDichVu { get; set; }
        public string? tenDichVu { get; set; }
        public string? tenPhong { get; set; }
    }
    public class GetDichVuDTO
    {
        public int ID { get; set; }
        public string? tenDichVu { get; set; }
    }


    public class GetDichVuSuDungDTO
    {
        public int IDPhong { get; set; }
        public int IDDichVu { get; set; }
        public string? tenDichVu { get; set; }
        public decimal giaDichVu { get; set; }
    }
}
