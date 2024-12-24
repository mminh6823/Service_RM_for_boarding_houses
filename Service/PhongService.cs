using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
namespace Service_PhongTro.Service
{
    public class PhongService
    {
        private readonly ApplicationDBContext _dbContext;

        public PhongService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GetLoaiPhongDTO> GetLoaiPhong()
        {
            return _dbContext.loaiPhong.Select(m => new GetLoaiPhongDTO
             {
                id = m.Id,
                tenLoaiPhong = m.tenLoaiPhong,
                giaPhong = m.gia,
                soNguoi = m.soNguoi
            }).ToList();
         }


    }
}
