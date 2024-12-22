using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.AspNetCore.Http.Metadata;
using System.Net.WebSockets;

namespace Service_PhongTro.Service
{
    public class DayTroService
    {
        private ApplicationDBContext _dBContext;

        public DayTroService(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

       
        public List<DayTro> GetDayTroList() => _dBContext.dayTro.ToList();

      
        public DayTro GetDayTroByID(int id)
        {
            var getbyid = _dBContext.dayTro.Where(m => m.Id == id).FirstOrDefault();
            return getbyid;
        }

       
        public DayTro AddDayTro(DayTroDTO dayTroDTO)
        {
            var check = _dBContext.dayTro.Any(m => m.tenDayTro == dayTroDTO.tenDayTro);
            if (check != true)
            {
                var _DayTro = new DayTro()
                {
                    tenDayTro = dayTroDTO.tenDayTro,
                    soLuongPhong = dayTroDTO.soLuongPhong
                };
                _dBContext.Add(_DayTro);
                _dBContext.SaveChanges();

                return _DayTro;
            }
            throw new Exception("Tên dãy trọ đã tồn tại! Vui lòng thêm tên khác");
        }


        
        public DayTro UpdateDayTro(int ID, DayTroDTO dayTroDTO)
        {
            var UdDayTro = _dBContext.dayTro.FirstOrDefault(m => m.Id == ID);
            var check = _dBContext.dayTro.Any(m => m.tenDayTro == dayTroDTO.tenDayTro && m.Id != ID);
            if (check != true)
            {
                if (UdDayTro != null)
                {
                    UdDayTro.tenDayTro = dayTroDTO.tenDayTro;
                    UdDayTro.soLuongPhong = dayTroDTO.soLuongPhong;
                    _dBContext.SaveChanges();
                }
                else
                {
                    throw new Exception( "Không tìm thấy dãy trọ cần cập nhật." );
                }
            }
            else
            {
                throw new Exception("Dãy trọ đã tồn tại, không thể cập nhật.");
            }
            return UdDayTro;

        }

       
        public void DeleteDayTro(int ID)
        {

            var idDelete = _dBContext.dayTro.FirstOrDefault(m => m.Id == ID);
            if (idDelete != null)
            {
                _dBContext.dayTro.Remove(idDelete);
                _dBContext.SaveChanges();
            }

        }
    }
}
