using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class DienNuocService
    {
        private readonly ApplicationDBContext _dbContext;
        public DienNuocService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GetPhongDTO> GetListTenphong()
        {
            var listdiennuoc = _dbContext.phong.Select(m =>
            new GetPhongDTO
            {
                Id = m.Id,
                tenPhong = m.tenPhong
            }).ToList();
            return listdiennuoc;
        }

        public IEnumerable<DienNuocDTO> GetDienNuoc()
        {
            var listDienNuoc = _dbContext.dienNuoc.Select(m =>
            new DienNuocDTO
            {
                Id = m.Id,
                IDPhong = m.IDPhong,
                thoiGianHoaDon = m.thoiGianHoaDon,
                tenPhong = _dbContext.phong.FirstOrDefault(n => n.Id == m.IDPhong).tenPhong,
                dienTieuThu = m.dienTieuThu,
                giaDien = m.giaDien,
                nuocTieuThu = m.nuocTieuThu,
                giaNuoc = m.giaNuoc
            }).ToList();
            return listDienNuoc;
        }

        public DienNuocDTO GetDienNuocId(int id)
        {
            var dienNuocbyID = _dbContext.dienNuoc
                .Where(m => m.Id == id)
                .Select(m => new DienNuocDTO
                {
                    Id = m.Id,
                    IDPhong = m.IDPhong,
                    thoiGianHoaDon = m.thoiGianHoaDon,
                    tenPhong = _dbContext.phong.FirstOrDefault(n => n.Id == m.IDPhong).tenPhong,
                    dienTieuThu = m.dienTieuThu,
                    giaDien = m.giaDien,
                    nuocTieuThu = m.nuocTieuThu,
                    giaNuoc = m.giaNuoc
                })
                .FirstOrDefault();
            return dienNuocbyID;
        }
        public DienNuoc AddDienNuoc(DienNuocDTO dienNuocDTO)
        {
            var _dienNuoc = new DienNuoc
            {
                IDPhong = dienNuocDTO.IDPhong,
                thoiGianHoaDon = dienNuocDTO.thoiGianHoaDon,
                dienTieuThu = dienNuocDTO.dienTieuThu,
                giaDien = dienNuocDTO.giaDien,
                nuocTieuThu = dienNuocDTO.nuocTieuThu,
                giaNuoc = dienNuocDTO.giaNuoc
            };
            if (_dienNuoc.Id == null)
            {
                throw new Exception("Id đã tồn tại! Vui lòng nhập lại");
            }
            _dbContext.dienNuoc.Add(_dienNuoc);
            _dbContext.SaveChanges();
            return _dienNuoc;
        }

        public DienNuoc DeleteDienNuoc(int id)
        {
            var deletedienNuoc = _dbContext.dienNuoc.FirstOrDefault(m => m.Id == id);
            if (deletedienNuoc != null)
            {
                _dbContext.dienNuoc.Remove(deletedienNuoc);
                _dbContext.SaveChanges();
            }
            return deletedienNuoc;
        }

    }
}
