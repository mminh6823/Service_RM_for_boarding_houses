using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class TaiKhoanNguoiDungService
    {
        private readonly ApplicationDBContext _dbContext;

        public TaiKhoanNguoiDungService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaiKhoanNguoiDung?> LoginNguoiDung(string taikhoan, string matkhau)
        {
            var _user = await _dbContext.taiKhoanNguoiDung.FirstOrDefaultAsync(m => m.CMND_CCCD == taikhoan && m.matKhau == matkhau);
            return _user;
        }
           public TaiKhoanNguoiDung AddTaiKhoanNguoiDung(TaiKhoanNguoiDungDTO taiKhoanNguoiDungDTO)
        {
            var _taikhoannguoidung = _dbContext.nguoiThue.FirstOrDefault(n => n.CMND_CCCD == taiKhoanNguoiDungDTO.CMND_CCCD);
            if (_taikhoannguoidung != null)
            {
                var newTaiKhoan = new TaiKhoanNguoiDung
                {
                    CMND_CCCD = _taikhoannguoidung.CMND_CCCD,
                    matKhau = taiKhoanNguoiDungDTO.matKhau
                    //Thêm các thuộc tính khác nếu cần
                };
                _dbContext.taiKhoanNguoiDung.Add(newTaiKhoan);
                _dbContext.SaveChanges();
                return newTaiKhoan;
            }
            else
            {
                throw new Exception( "Không tìm thấy thông tin nguoiThue");
            }
        }

        public IEnumerable<NguoiThueDTO> GetAllNguoiThue()
        {
            var _nguoithue = _dbContext.nguoiThue.ToList().Select(n => new NguoiThueDTO
            {
                hoTen = n.hoTen,
                CMND_CCCD = n.CMND_CCCD,
            });
            return _nguoithue;
        }
        public List<TaiKhoanNguoiDung> GetTaikhoanNguoiDungs() => _dbContext.taiKhoanNguoiDung.ToList();
        public TaiKhoanNguoiDung? GetTaikhoanNguoiDungId(int id)
        {
            return _dbContext.taiKhoanNguoiDung.FirstOrDefault(n => n.Id == id);
        }
        public TaiKhoanNguoiDung UpdateTaiKhoanNguoiDungId(int TaiKhoanNguoiDungId, TaiKhoanNguoiDungDTO taiKhoanNguoiDungDTO)
        {
            var _taikhoannguoidung = _dbContext.taiKhoanNguoiDung.FirstOrDefault(n => n.Id == TaiKhoanNguoiDungId);
            if (_taikhoannguoidung != null)
            {
                _taikhoannguoidung.CMND_CCCD = taiKhoanNguoiDungDTO.CMND_CCCD;
                _taikhoannguoidung.matKhau = taiKhoanNguoiDungDTO.matKhau;

                _dbContext.SaveChanges();
            }
            return _taikhoannguoidung;
        }

        public TaiKhoanNguoiDung DeleteTaiKhoanNguoidungId(int id)
        {
            var TKND = _dbContext.taiKhoanNguoiDung.FirstOrDefault(n => n.Id == id);
            if (TKND != null)
            {
                _dbContext.taiKhoanNguoiDung.Remove(TKND);
                _dbContext.SaveChanges();
            }
            return TKND;
        }
    }
}
