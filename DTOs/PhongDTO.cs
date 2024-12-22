namespace Service_PhongTro.DTOs
{
    public class PhongDTO
    {
        public int id { get; set; }
        public string? tenPhong { get; set; }
        public int IDLoaiPhong { get; set; }
        public string? tenLoaiPhong { get; set; }
        public string? tenDayTro { get; set; }
        public bool? conPhong { get; set; }
        public int IDDayTro { get; set; }
        public int SoNguoiDangO { get; set; }
        public int soNguoi { get; set; }
    }

    public class GetLoaiPhongDTO
    {
        public int id { get; set; }
        public string? tenLoaiPhong { get; set; }
        public decimal? giaPhong { get; set; }
        public int soNguoi { get; set; }
    }

    public class GetDayTroDTO
    {
        public int id { get; set; }
        public string? tenDayTro { get; set; }
    }

}
