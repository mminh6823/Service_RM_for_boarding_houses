using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly HoaDonService hoaDonService;

        public HoaDonController(HoaDonService hoaDonService)
        {
            this.hoaDonService = hoaDonService;
        }
        [HttpGet("get-all-hoadon")]
        public IActionResult GetAllHoaDon()
        {
            var listHoaDon = hoaDonService.GetAllHoaDon();
            return Ok(listHoaDon);
        }

        [HttpPost("add-hoadon")]
        public IActionResult AddHoaDon([FromBody] HoaDonDTO hoaDonDTO)
        {
            var result = hoaDonService.AddHoaDon(hoaDonDTO);
            return Ok(result);
        }

        [HttpDelete("delete-hoadon")]
        public IActionResult DeleteHoaDon([FromQuery] int id)
        {
             hoaDonService.DeleteHoaDon(id);
            return StatusCode(202, $"Xóa thành công hóa đơn có id = {id}");
        }

    }
}
