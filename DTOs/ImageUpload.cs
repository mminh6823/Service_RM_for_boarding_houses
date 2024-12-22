namespace Service_PhongTro.DTOs
{
    public class ImageUpload
    {
        public IFormFile? AnhDaiDien { get; set; }
        public IFormFile? MatTruocCCCD { get; set; }
        public IFormFile? MatSauCMND { get; set; }
        public List<IFormFile>? OtherImages { get; set; }
    }
}
