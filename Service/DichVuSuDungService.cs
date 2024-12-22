using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class DichVuSuDungService
    {
        private readonly ApplicationDBContext _dbContext;

        public DichVuSuDungService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

    /*   public IEnumerable<Phong> getAllDichVuPhong()
        {
            var _phong = _dbContext.phong.ToList().Select(phong => 
            new Phong
            {
                Id = phong.Id,
                tenPhong = phong.tenPhong,
            });
            return _phong;
        }*/ 

    }
}
