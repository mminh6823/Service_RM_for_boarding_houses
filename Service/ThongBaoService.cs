using Service_PhongTro.DTOs;
using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class ThongBaoService
    {
        private readonly ApplicationDBContext _context;

        public ThongBaoService(ApplicationDBContext context)
        {
            _context = context;
        }
        public ThongBao CreateThongBaoAsync(ThongBaoDTO thongBaoDTO)
        {
            var _thongbao = new ThongBao()
            {
                ngayDang = DateTime.Now,
                tieuDe = thongBaoDTO.tieuDe,
                moTa = thongBaoDTO.moTa,
            };
            _context.Add(_thongbao);
            _context.SaveChanges();
            return _thongbao;
        }

        public List<ThongBao> GetallThongBao() => _context.thongBao.ToList();
        public ThongBao? GetThongBaoAsync(int id) => _context.thongBao.FirstOrDefault(n => n.Id == id);


        public ThongBao? UpdateThongBaoAsync(int id, ThongBaoDTO thongBaoDTO)
        {
            var _thongbao = _context.thongBao.FirstOrDefault(n => n.Id == id);
            if (_thongbao != null)
            {
                _thongbao.ngayDang = DateTime.Now;
                _thongbao.tieuDe = thongBaoDTO.tieuDe;
                _thongbao.moTa = thongBaoDTO.moTa;

                _context.SaveChanges();
            }
            return _thongbao;
        }

        public ThongBao? DeleteThongBaoAsync(int id)
        {
            var thongBao = _context.thongBao.FirstOrDefault(n => n.Id == id);
            if (thongBao != null)
            {
                _context.thongBao.Remove(thongBao);
                _context.SaveChanges();
            }
            return thongBao;
        }


    }
}
