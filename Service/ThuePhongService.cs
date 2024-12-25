using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using System.Net.WebSockets;

namespace Service_PhongTro.Service
{
    public class ThuePhongService
    {
        private readonly ApplicationDBContext  _context;

        public ThuePhongService(ApplicationDBContext context)
        {
            _context = context;
        }
        public IEnumerable<GetPhongDTO> GetAllPhongVM()
        {
            var _phong = _context.phong.ToList().Select(ph => new GetPhongDTO
            {
                Id = ph.Id,
                tenPhong = ph.tenPhong
            });
            return _phong;
        }

        public IEnumerable<GetLoaiPhongDTO> GetAllLoaiPhong()
        {
            var _loaiphong = _context.loaiPhong.ToList().Select(lp => new GetLoaiPhongDTO
            {
                id = lp.Id,
                tenLoaiPhong = lp.tenLoaiPhong,
                giaPhong = lp.gia
            });
            return _loaiphong;
        }

        public IEnumerable<GetNguoiThueDTO> GetAllNguoiThueVM()
        {
            var _nguoithue = _context.nguoiThue.ToList().Select(nt => new GetNguoiThueDTO
            {
                Id = nt.Id,
                tenNguoithue = nt.hoTen
            });

            return _nguoithue;
        }

        public IEnumerable<GetDichVuSuDungDTO> GetAllDichVuSuDungVM()
        {
            var _dichvu = _context.dichVu.ToList().Select(dv => new GetDichVuSuDungDTO
            {
                IDDichVu = dv.Id,
                tenDichVu = dv.tenDichVu,
                giaDichVu = dv.giaDichVu,
            });
            return _dichvu;
        }

        public IEnumerable<GetdienNuocDTO> GetAlldienNuocVM()
        {
            var _diennuoc = _context.dienNuoc.ToList().Select(dn => new GetdienNuocDTO
            {
                Id = dn.Id,
                dienTieuThu = dn.dienTieuThu,
                giaDien = dn.giaDien,
                nuocTieuThu = dn.nuocTieuThu,
                giaNuoc = dn.giaNuoc,
            });
            return _diennuoc;
        }

        public IEnumerable<ThuePhongDTO?> GetThuePhongs()
        {
            var _thuephong = _context.thuePhong.ToList().Select(tp => new ThuePhongDTO
            {
                Id = tp.Id,
                IDPhong = tp.IDPhong,
                IDNguoiThue = tp.IDNguoiThue,
                tenNguoithue = _context.nguoiThue.FirstOrDefault(n => n.Id == tp.IDNguoiThue)?.hoTen ?? string.Empty,
                tenPhong = _context.phong.FirstOrDefault(p => p.Id == tp.IDPhong)?.tenPhong ?? string.Empty,
                ngayThue = tp.ngayThue,
                ngayTra = tp.ngayTra,
                tienCoc = tp.tienCoc,
            });
            return _thuephong;
        }
        public ThuePhong AddThuePhong(ThuePhongDTO thuePhongDTO)
        {
            var _thuephong = new ThuePhong()
            {
                IDPhong = thuePhongDTO.IDPhong,
                IDNguoiThue = thuePhongDTO.IDNguoiThue,
                ngayThue = thuePhongDTO.ngayThue,
                ngayTra = thuePhongDTO.ngayTra,
                tienCoc = thuePhongDTO.tienCoc
            };
            _context.thuePhong.Add(_thuephong);
            _context.SaveChanges();

            return _thuephong;
        }

        public ThuePhong? UpdateThuePhongId(int thuephongId, ThuePhongDTO thuePhongDTO)
        {
            var _thuephong = _context.thuePhong.FirstOrDefault(n => n.Id == thuephongId);
            if (_thuephong != null)
            {
                _thuephong.IDPhong = thuePhongDTO.IDPhong;
                _thuephong.IDNguoiThue = thuePhongDTO.IDNguoiThue;
                _thuephong.ngayThue = thuePhongDTO.ngayThue;
                _thuephong.ngayTra = thuePhongDTO.ngayTra;
                _thuephong.tienCoc = thuePhongDTO.tienCoc;

                _context.SaveChanges();
            };

            return _thuephong;
        }
        public decimal TinhTongTien(int thuePhongId)
        {
            try
            {

                var thuePhongExists = _context.thuePhong.Any(tp => tp.Id == thuePhongId);
                if (!thuePhongExists)
                {
                    throw new Exception($"Không tìm thấy bản ghi nào trong thuePhong với Id = {thuePhongId}");
                }
                var tientheoLoaiPhong = (from tp in _context.thuePhong
                                         join p in _context.phong on tp.IDPhong equals p.Id
                                         join lp in _context.loaiPhong on p.IDLoaiPhong equals lp.Id
                                         where tp.Id == thuePhongId
                                         select lp.gia).FirstOrDefault();
 
               var tongtientheodichvu = (from tp in _context.thuePhong
                                          join p in _context.phong on tp.IDPhong equals p.Id
                                          join dvsudung in _context.dichVuSuDung on p.Id equals dvsudung.IDPhong
                                          join dv in _context.dichVu on dvsudung.IDDichVu equals dv.Id
                                          where tp.Id == thuePhongId
                                          select dv.giaDichVu).Sum();

                // Tính tiền điện nước theo id phòng và thời gian gần nhất
                var tongDienNuoc = (from tp in _context.thuePhong
                                    join p in _context.phong on tp.IDPhong equals p.Id
                                    join dn in _context.dienNuoc on p.Id equals dn.IDPhong
                                    where tp.Id == thuePhongId && dn.thoiGianHoaDon == (from d in _context.dienNuoc
                                                                                        where d.IDPhong == p.Id
                                                                                        orderby d.thoiGianHoaDon descending
                                                                                        select d.thoiGianHoaDon).FirstOrDefault()
                                    select (dn.giaDien * dn.dienTieuThu)+(dn.giaNuoc * dn.nuocTieuThu)).FirstOrDefault();

                if (tientheoLoaiPhong == null|| tongtientheodichvu == null || tongDienNuoc == null)
                {
                    throw new Exception("1 trong những dịch vụ không tồn tại hoặc bị null.");
                }

                decimal tongF = tongtientheodichvu + tongDienNuoc + (decimal)tientheoLoaiPhong;

                return tongF;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tính tổng tiền: {ex.Message}");
            }
        }



        public async Task<ThuePhong?> DeleteThuePhongId(int id)
        {
            var _delete = await _context.thuePhong.FirstOrDefaultAsync(n => n.Id == id);
            if (_delete != null)
            {
                _context.thuePhong.Remove(_delete);
                _context.SaveChanges();
            }
            return _delete;
        }
    }
}
