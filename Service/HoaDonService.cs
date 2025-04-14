using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using System.Net.WebSockets;

namespace Service_PhongTro.Service
{
    public class HoaDonService
    {
        private readonly ApplicationDBContext _context;

        public HoaDonService(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<HoaDon> GetAllHoaDon()
        {
            var listhoadon = _context.hoaDon
                .Include(m=>m.ThuePhong)
                .ThenInclude(n=>n.nguoiThue)
                .ToList();
            return listhoadon;
        }

        public decimal tongTienHoaDon(int idthuephong)
        {
            try
            {
                var tongtien = (
                    from tp in _context.thuePhong
                    join p in _context.phong on tp.IDPhong equals p.Id
                    join lp in _context.loaiPhong on p.IDLoaiPhong equals lp.Id
                    join dvsudung in _context.dichVuSuDung on p.Id equals dvsudung.IDPhong into dvGroup
                    from dvs in dvGroup.DefaultIfEmpty()
                    join dv in _context.dichVu on dvs.IDDichVu equals dv.Id into dvJoin
                    from dichvu in dvJoin.DefaultIfEmpty()
                    join dn in _context.dienNuoc on p.Id equals dn.IDPhong into dnGroup
                    from diennuoc in dnGroup
                        .Where(d => d.thoiGianHoaDon == _context.dienNuoc
                            .Where(x => x.IDPhong == p.Id)
                            .Max(x => x.thoiGianHoaDon))
                        .DefaultIfEmpty()
                    where tp.Id == idthuephong
                    group new { lp, dichvu, diennuoc, tp } by new { lp.gia, tp.tienCoc } into g
                    select new
                    {
                        TienLoaiPhong = g.Key.gia,
                        TienCoc = g.Key.tienCoc,
                        TongTienDichVu = g.Sum(x => x.dichvu != null ? x.dichvu.giaDichVu : 0),
                        TongDienNuoc = g.Sum(x => x.diennuoc != null ? (x.diennuoc.giaDien * x.diennuoc.dienTieuThu) + (x.diennuoc.giaNuoc * x.diennuoc.nuocTieuThu) : 0)
                    }).FirstOrDefault();

                decimal tongtienthanhtoan = (tongtien?.TongTienDichVu ?? 0) + (tongtien?.TongDienNuoc ?? 0) + (tongtien?.TienLoaiPhong ?? 0) - (tongtien?.TienCoc ?? 0);

                return tongtienthanhtoan;

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tính tổng tiền: {ex.Message}");
            }
        }



        public HoaDon AddHoaDon([FromBody] HoaDonDTO hoaDonDTO)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (hoaDonDTO == null || hoaDonDTO.IDThuePhong <= 0)
                {
                    throw new Exception("Dữ liệu hóa đơn không hợp lệ.");
                }

                var _hoadon = new HoaDon
                {
                    IDThuePhong = hoaDonDTO.IDThuePhong,
                    NgayThanhToan = hoaDonDTO.NgayThanhToan,
                    TongTienThanhToan = tongTienHoaDon(hoaDonDTO.IDThuePhong),
                    TrangThai = hoaDonDTO.TrangThai,
                    GhiChu = hoaDonDTO.TrangThai == 1 ? "Thanh toán thành công bằng tiền mặt! " : "Thanh toán thành công bằng phương thức khác! (Không phải tiền mặt)"
                };

                _context.hoaDon.Add(_hoadon);
                _context.SaveChanges();
                return _hoadon;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm hóa đơn: {ex.Message}");
            }
        }

        public void DeleteHoaDon([FromQuery] int id )
        {
            var delete =_context.hoaDon.FirstOrDefault(m=>m.Id == id);
            _context.Remove(delete);
            _context.SaveChanges();
        }
    }
}
