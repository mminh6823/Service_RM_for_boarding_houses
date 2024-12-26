namespace Service_PhongTro.DTOs
{
    public class ThuePhongDTO
    {
        public int Id { get; set; }
        public int IDPhong { get; set; }
        public int IDNguoiThue { get; set; }
        public DateTime ngayThue { get; set; }
        public DateTime ngayTra { get; set; }
        public decimal tienCoc { get; set; }
        public string? tenNguoithue { get; set; }
        public string? tenPhong { get; set; }
    }
    public class GetNguoiThueDTO
    {
        public int Id { get; set; }

        public string? tenNguoithue { get; set; }
    }

    public class GetdienNuocDTO
    {
        public int Id { get; set; }
        public int dienTieuThu { get; set; }
        public decimal giaDien { get; set; }
        public int nuocTieuThu { get; set; }
        public decimal giaNuoc { get; set; }
    }

    public class GetDichVumoiDTO
    {
        public int Id { get; set; }
        public decimal giaDichVu { get; set; }

    }

    public class GetThuePhongGetDTO
    {
        public int dienTieuThu { get; set; }
        public decimal giaDien { get; set; }
        public int nuocTieuThu { get; set; }
        public decimal giaNuoc { get; set; }
        public int IDPhong { get; set; }
        public int IDDichVu { get; set; }
        public string? tenDichVu { get; set; }
        public decimal giaDichVu { get; set; }
        public string? tenLoaiPhong { get; set; }
        public decimal? giaPhong { get; set; }
        public string? tenPhong { get; set; }

    }
}
