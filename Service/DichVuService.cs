using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;

namespace Service_PhongTro.Service
{
    public class DichVuService
    {
        private ApplicationDBContext _dBContext;

        public DichVuService(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
          public List<DichVu> GetListDichVu() => _dBContext.dichVu.ToList();     
          public List<DichVu> GetDichVubyID(int? id) =>(id.HasValue && id != 0) 
            ? _dBContext.dichVu.Where(m=>m.Id == id).ToList()
            : _dBContext.dichVu.ToList(); 
           public DichVu AddDichVu(DichVuDTO dichVuDTO)
        {   
            var checkname = _dBContext.dichVu.Any(m => m.tenDichVu == dichVuDTO.tenDichVu);
            if (checkname != true)
            {
                var dichVu = new DichVu() { 
                tenDichVu = dichVuDTO.tenDichVu,
                giaDichVu = dichVuDTO.giaDichVu
                };
                _dBContext.Add(dichVu);
                _dBContext.SaveChanges();
                return (dichVu);
            }
            throw new Exception("Tên dịch vụ đã tồn tại vui lòng thử lại! ");
        }
           
        public DichVu UpdateDichVu(int id, DichVuDTO dichVuDTO)
        {
            var udDichVu= _dBContext.dichVu.FirstOrDefault(m=>m.Id == id);  
            var checkid = _dBContext.dichVu.Any(m => m.tenDichVu == dichVuDTO.tenDichVu && m.Id != id);
            if (checkid != true)
            {
                if (udDichVu != null)
                {
                    udDichVu.tenDichVu = dichVuDTO.tenDichVu;
                    udDichVu.giaDichVu = dichVuDTO .giaDichVu;
                    _dBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy dịch vụ cần cập nhật!");
                }
            }
            else {
                throw new Exception("Tên dịch vụ đã tồn tại! Vui lòng nhập");
            }
            return udDichVu;
        }
        public string DeleteDichVu(int? id)
        {
            if (id.HasValue && id != 0)
            {
                var deleteDV = _dBContext.dichVu.FirstOrDefault(m => m.Id == id);
                if (deleteDV != null)
                {
                    _dBContext.Remove(deleteDV);
                    _dBContext.SaveChanges(); // Lưu thay đổi vào database
                }
                throw new KeyNotFoundException($"Không tìm thấy dịch vụ với Id = {id}."); // Ngoại lệ cụ thể hơn
            }
            throw new ArgumentException("Id không hợp lệ. Vui lòng nhập lại.");

        }
    }
}
