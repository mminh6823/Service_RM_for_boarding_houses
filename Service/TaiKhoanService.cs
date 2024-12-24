using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class TaiKhoanService
    {
        private readonly ApplicationDBContext _dbContext;

        public TaiKhoanService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTaiKhoan(TaiKhoanDTO taiKhoanDTO)
        {
            var _TaiKhoan = new TaiKhoan()
            {
                taiKhoan = taiKhoanDTO.taiKhoan,
                matKhau = taiKhoanDTO.matKhau
            };
            _dbContext.taiKhoan.Add(_TaiKhoan);
            _dbContext.SaveChanges();
        }

        public bool CheckLogin(string TaiKhoan, string MatKhau)
        {
            var user = _dbContext.taiKhoan
                .FirstOrDefault(u => u.taiKhoan == TaiKhoan && u.matKhau == MatKhau);

            return user != null;
        }
        public List<TaiKhoan> GetTaiKhoans() => _dbContext.taiKhoan.ToList();

        public TaiKhoan? GetTaiKhoanId(int id) => _dbContext.taiKhoan.FirstOrDefault(n => n.Id == id);

        public TaiKhoan? UpdateTaiKhoanId(int TaiKhoanid, TaiKhoanDTO taiKhoanVM)
        {
            var _Taikhoan = _dbContext.taiKhoan.FirstOrDefault(n => n.Id == TaiKhoanid);
            if (_Taikhoan != null)
            {
                _Taikhoan.taiKhoan = taiKhoanVM.taiKhoan;
                _Taikhoan.matKhau = taiKhoanVM.matKhau;

                _dbContext.SaveChanges();
            }
            return _Taikhoan;
        }

        public TaiKhoan? DeleteTaiKhoanId(int id)
        {
            var tk = _dbContext.taiKhoan.FirstOrDefault(n => n.Id == id);
            if (tk != null)
            {
                _dbContext.taiKhoan.Remove(tk);
                _dbContext.SaveChanges();
            }

            return tk;
        }

    }
}
