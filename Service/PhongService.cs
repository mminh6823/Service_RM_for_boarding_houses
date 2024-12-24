using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using System.Net.WebSockets;
namespace Service_PhongTro.Service
{
    public class PhongService
    {
        private readonly ApplicationDBContext _dbContext;

        public PhongService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GetLoaiPhongDTO> GetLoaiPhongDTO()
        {
            return _dbContext.loaiPhong.Select(m => new GetLoaiPhongDTO
            {
                id = m.Id,
                tenLoaiPhong = m.tenLoaiPhong,
                giaPhong = m.gia,
                soNguoi = m.soNguoi
            }).ToList();
        }
        public IEnumerable<GetDayTroDTO> getDayTroDTO()
        {
            return _dbContext.dayTro.Select(m => new GetDayTroDTO
            {
                id = m.Id,
                tenDayTro = m.tenDayTro
            }).ToList();
        }
        public Phong AddPhong(PhongDTO phongDTO)
        {
            var phong = new Phong
            {
                tenPhong = phongDTO.tenPhong,
                IDLoaiPhong = phongDTO.IDLoaiPhong,
                IDDayTro = phongDTO.IDDayTro,
                SoNguoiDangO = 0,
                conPhong = true
            };
            _dbContext.phong.Add(phong);
            _dbContext.SaveChanges();
            return phong;
        }

        public IEnumerable<PhongDTO> GetallPhong()
        {
            var _phong = _dbContext.phong.Select(m=> new PhongDTO
            {
                id = m.Id,
                tenPhong = m.tenPhong,
                IDLoaiPhong = m.IDLoaiPhong,
                tenLoaiPhong = _dbContext.loaiPhong.FirstOrDefault(n => n.Id == m.IDLoaiPhong).tenLoaiPhong,
                tenDayTro = _dbContext.dayTro.FirstOrDefault(n => n.Id == m.IDDayTro).tenDayTro,
                conPhong = m.conPhong,
                IDDayTro = m.IDDayTro,
                SoNguoiDangO = m.SoNguoiDangO,
                soNguoi = _dbContext.loaiPhong.FirstOrDefault(n => n.Id == m.IDLoaiPhong).soNguoi
            }).ToList();
            return _phong;
        }
        public Phong? UpdatePhong(int id, PhongDTO phongDTO)
        {
            var phong = _dbContext.phong.Find(id);
            if (phong != null)
            {
                phong.tenPhong = phongDTO.tenPhong;
                phong.IDLoaiPhong = phongDTO.IDLoaiPhong;
                phong.IDDayTro = phongDTO.IDDayTro;
                phong.SoNguoiDangO = phongDTO.soNguoi;
                _dbContext.SaveChanges();
            }
            return phong;
        }
        public Phong? DeletePhong(int id)
        {
            var phong = _dbContext.phong.Find(id);
            if (phong != null)
            {
                _dbContext.phong.Remove(phong);
                _dbContext.SaveChanges();
            }
            return phong;
        }

    }
}
