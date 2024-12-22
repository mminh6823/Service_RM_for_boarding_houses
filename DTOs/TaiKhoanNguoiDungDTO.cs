namespace Service_PhongTro.DTOs
{
    public class TaiKhoanNguoiDungDTO
    {
        public string CMND_CCCD { get; set; }
        public string matKhau { get; set; }
    }

    public class NguoithueGetDTO
    {
        public int Id { get; set; }
        public string? hoTen { get; set; }
        public string? CMND_CCCD { get; set; }
    }
}
