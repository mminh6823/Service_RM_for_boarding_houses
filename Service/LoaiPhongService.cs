using Service_PhongTro.DTOs;
using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class LoaiPhongService
    {
        private readonly ApplicationDBContext _dBContext;

        public LoaiPhongService(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<LoaiPhong> GetLoaiPhong() => _dBContext.loaiPhong.ToList();

        public IEnumerable<LoaiPhong> GetLoaiPhongbyID(int id) => _dBContext.loaiPhong.Where(m => m.Id == id).ToList();

        public LoaiPhong AddLoaiPhong(LoaiPhongDTO loaiPhongDTO)
        {
            var loaiPhong = new LoaiPhong
            {
                tenLoaiPhong = loaiPhongDTO.tenLoaiPhong,
                gia = loaiPhongDTO.gia,
                soNguoi = loaiPhongDTO.soNguoi
            };
            _dBContext.loaiPhong.Add(loaiPhong);
            _dBContext.SaveChanges();
            return loaiPhong;
        }

        public LoaiPhong UpdateLoaiPhong(int id, LoaiPhongDTO loaiPhongDTO)
        {
            var loaiPhong = _dBContext.loaiPhong.Find(id);
            if (loaiPhong != null)
            {
                loaiPhong.tenLoaiPhong = loaiPhongDTO.tenLoaiPhong;
                loaiPhong.gia = loaiPhongDTO.gia;
                loaiPhong.soNguoi = loaiPhongDTO.soNguoi;
                _dBContext.SaveChanges();
            }
            return loaiPhong;
        }

        public LoaiPhong DeleteLoaiPhong(int id)
        {
            var loaiPhong = _dBContext.loaiPhong.Find(id);
            if (loaiPhong != null)
            {
                _dBContext.loaiPhong.Remove(loaiPhong);
                _dBContext.SaveChanges();
            }
            return loaiPhong;
        }

    }
}
