using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using System.Net.WebSockets;

namespace Service_PhongTro.Service
{
    public class DichVuSuDungService
    {
        private readonly ApplicationDBContext _dbContext;

        public DichVuSuDungService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GetPhongDTO> getAllDichVuPhong()
        {
            var _phong = _dbContext.phong.Select(phong =>
            new GetPhongDTO
            {
                Id = phong.Id,
                tenPhong = phong.tenPhong,
            }).ToList();
            return _phong;
        }
        public IEnumerable<GetDichVuDTO> getAllDichVu()
        {
            var _dichvu = _dbContext.dichVu.Select(m =>
            new GetDichVuDTO
            {
                ID = m.Id,
                tenDichVu = m.tenDichVu,
            }).ToList();
            return _dichvu;
        }
        public IEnumerable<DichVuSuDungDTO> getDichVuSuDung()
        {
            var _dichVuSuDung = _dbContext.dichVuSuDung.Select(m =>
            new DichVuSuDungDTO
            {
                IDDichVu = m.IDDichVu,
                IDPhong = m.IDPhong,
                tenDichVu = _dbContext.dichVu.FirstOrDefault(a => a.Id == m.IDDichVu).tenDichVu,
                tenPhong = _dbContext.phong.FirstOrDefault(b => b.Id == m.IDPhong).tenPhong
            }).ToList();
            return _dichVuSuDung;
        }
        public DichVuSuDung AddDichVuSuDung(GetDichVuSuDungDTO dichVuSuDungDTO)
        {
            var checkname = _dbContext.dichVuSuDung.Any(m => m.IDDichVu == dichVuSuDungDTO.IDDichVu && m.IDPhong == dichVuSuDungDTO.IDPhong);
            if (checkname != true)
            {
                var dichVuSuDung = new DichVuSuDung()
                {
                    IDDichVu = dichVuSuDungDTO.IDDichVu,
                    IDPhong = dichVuSuDungDTO.IDPhong,
                };
                _dbContext.dichVuSuDung.Add(dichVuSuDung);
                _dbContext.SaveChanges();
                return (dichVuSuDung);
            }
            throw new Exception("Dịch vụ sử dụng đã tồn tại vui lòng thử lại! ");
        }
        public DichVuSuDung DeleteDichVuSuDung(int? iddichvu, int? idphong)
        {
            var deletedvsd= _dbContext.dichVuSuDung.FirstOrDefault(m => m.IDDichVu== iddichvu && m.IDPhong== idphong);
            if (deletedvsd!=null)
            {
                _dbContext.dichVuSuDung.Remove(deletedvsd);
                _dbContext.SaveChanges();
            }
            return deletedvsd;
        }



    }
}
