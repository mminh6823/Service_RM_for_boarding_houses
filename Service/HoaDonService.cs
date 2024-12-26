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
                // Lấy tiền theo loại phòng
                var tientheoLoaiPhong = (
                                         from tp in _context.thuePhong 
                                         join p in _context.phong on tp.IDPhong equals p.Id
                                         join lp in _context.loaiPhong on p.IDLoaiPhong equals lp.Id
                                         where tp.Id == idthuephong
                                         select lp.gia).FirstOrDefault() ?? 0;

                // Tính tổng tiền dịch vụ
                var tongtientheodichvu = (
                                          from tp in _context.thuePhong 
                                          join p in _context.phong on tp.IDPhong equals p.Id
                                          join dvsudung in _context.dichVuSuDung on p.Id equals dvsudung.IDPhong
                                          join dv in _context.dichVu on dvsudung.IDDichVu equals dv.Id
                                          where tp.Id == idthuephong
                                          select dv.giaDichVu).Sum() ;

                // Tính tiền điện nước
                var tongDienNuoc = (
                                     from tp in _context.thuePhong 
                                    join p in _context.phong on tp.IDPhong equals p.Id
                                    join dn in _context.dienNuoc on p.Id equals dn.IDPhong
                                    where tp.Id == idthuephong &&
                                          dn.thoiGianHoaDon == (from d in _context.dienNuoc
                                                                where d.IDPhong == p.Id
                                                                orderby d.thoiGianHoaDon descending
                                                                select d.thoiGianHoaDon).FirstOrDefault()
                                    select (dn.giaDien * dn.dienTieuThu) + (dn.giaNuoc * dn.nuocTieuThu)).FirstOrDefault();

                // Tiền cọc
                var tiencoc = (
                               from tp in _context.thuePhong 
                               where tp.Id == idthuephong
                               select tp.tienCoc).FirstOrDefault() ;

                // Tính tổng tiền thanh toán
                decimal tongtienthanhtoan = (tongtientheodichvu + tongDienNuoc + tientheoLoaiPhong) - tiencoc;

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
