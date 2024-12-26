using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class NguoiThueService
    {
        private readonly ApplicationDBContext _context;

        public NguoiThueService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<NguoiThueDTO> CreateNguoiThue(NguoiThueDTO nguoiThueDTO, IFormFile? anhDaiDien, IFormFile? matTruocCCCD, IFormFile? matSauCMND)
        {
            try
            {
                var taikhoan = await _context.taiKhoanNguoiDung.Where(x => x.CMND_CCCD == nguoiThueDTO.CMND_CCCD).FirstOrDefaultAsync();

                if (taikhoan == null)
                {
                    taikhoan = new TaiKhoanNguoiDung
                    {
                        CMND_CCCD = nguoiThueDTO.CMND_CCCD,
                        matKhau = nguoiThueDTO.CMND_CCCD
                    };

                    _context.Add(taikhoan);
                    await _context.SaveChangesAsync();
                }

                var _nguoiThue = new NguoiThue()
                {
                    hoTen = nguoiThueDTO.hoTen,
                    gioiTinh = nguoiThueDTO.gioiTinh,
                    SDT = nguoiThueDTO.SDT,
                    queQuan = nguoiThueDTO.queQuan,
                    ngaySinh = nguoiThueDTO.ngaySinh,
                    CMND_CCCD = nguoiThueDTO.CMND_CCCD,
                    Email = nguoiThueDTO.Email,
                    anhDaiDien = anhDaiDien != null ? Path.GetFileName(anhDaiDien.FileName) : null,
                    matTruocCCCD = matTruocCCCD != null ? Path.GetFileName(matTruocCCCD.FileName) : null,
                    matSauCMND = matSauCMND != null ? Path.GetFileName(matSauCMND.FileName) : null
                };

                Console.WriteLine(anhDaiDien);

                //Lưu avt và cccd mặt trước, sau 
                if (anhDaiDien != null && anhDaiDien.Length > 0)
                {
                    string path = Path.GetFullPath("D:\\.Net\\Service_PhongTro\\Service_PhongTro\\DownLoad_InforNguoiThue");
                    using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.anhDaiDien), FileMode.Create))
                    {
                        await anhDaiDien.CopyToAsync(filestream);
                    }
                }

                if (matTruocCCCD != null && matTruocCCCD.Length > 0)
                {
                    string pathh = Path.GetFullPath("D:\\.Net\\Service_PhongTro\\Service_PhongTro\\DownLoad_InforNguoiThue");
                    using (var filestream = new FileStream(Path.Combine(pathh, _nguoiThue.matTruocCCCD), FileMode.Create))
                    {
                        await matTruocCCCD.CopyToAsync(filestream);
                    }
                }

                if (matSauCMND != null && matSauCMND.Length > 0)
                {
                    string pathhh = Path.GetFullPath("D:\\.Net\\Service_PhongTro\\Service_PhongTro\\DownLoad_InforNguoiThue");
                    using (var filestream = new FileStream(Path.Combine(pathhh, _nguoiThue.matSauCMND), FileMode.Create))
                    {
                        await matSauCMND.CopyToAsync(filestream);
                    }
                }

                _context.nguoiThue.Add(_nguoiThue);
                _context.SaveChanges();

                return nguoiThueDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating NguoiThue: {ex.Message}");
            }
        }

        public async Task<NguoiThueDTO> UpdateNguoiThue(int id, NguoiThueDTO updatedNguoiThueDTO, IFormFile anhDaiDien, IFormFile matTruocCCCD, IFormFile matSauCMND)
        {
            var _nguoiThue = await _context.nguoiThue.FirstOrDefaultAsync(x => x.Id == id);

            var taikhoan = await _context.taiKhoanNguoiDung.Where(x => x.CMND_CCCD == updatedNguoiThueDTO.CMND_CCCD).FirstOrDefaultAsync();
            if (taikhoan != null)
            {
                taikhoan.CMND_CCCD = updatedNguoiThueDTO.CMND_CCCD;
                taikhoan.matKhau = updatedNguoiThueDTO.CMND_CCCD;
                _context.Update(taikhoan);
                await _context.SaveChangesAsync();
            }

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Static"));

            if (anhDaiDien != null && anhDaiDien.Length > 0)
            {
                _nguoiThue.anhDaiDien = Path.GetFileName(anhDaiDien.FileName);
                using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.anhDaiDien), FileMode.Create))
                {
                    await anhDaiDien.CopyToAsync(filestream);
                }
            }

            if (matTruocCCCD != null && matTruocCCCD.Length > 0)
            {
                _nguoiThue.matTruocCCCD = Path.GetFileName(matTruocCCCD.FileName);
                using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.matTruocCCCD), FileMode.Create))
                {
                    await matTruocCCCD.CopyToAsync(filestream);
                }
            }

            if (matSauCMND != null && matSauCMND.Length > 0)
            {
                _nguoiThue.matSauCMND = Path.GetFileName(matSauCMND.FileName);
                using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.matSauCMND), FileMode.Create))
                {
                    await matSauCMND.CopyToAsync(filestream);
                }
            }
            _context.nguoiThue.Update(_nguoiThue);
            await _context.SaveChangesAsync();

            return updatedNguoiThueDTO;
        }

        public void DeleteNguoiThue(int? id)
        {
            var _nguoiThue = _context.nguoiThue.FirstOrDefault(n => n.Id == id);
            if (_nguoiThue != null)
            {
                _context.nguoiThue.Remove(_nguoiThue);
                _context.SaveChanges();
            }
        }

        public List<NguoiThue> GetAllNguoiThue() => _context.nguoiThue.Include(m=>m.thuePhong).ToList();

    }
}
