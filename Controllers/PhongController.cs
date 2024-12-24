using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly PhongService _phongService;

        public PhongController(PhongService phongService)
        {
            _phongService = phongService;
        }

        [HttpGet("get-loai-phong")]
        public IActionResult GetLoaiPhong()
        {
            var loaiPhong = _phongService.GetLoaiPhongDTO();
            return Ok(loaiPhong);
        }

        [HttpGet("get-day-tro")]
        public IActionResult GetDayTro()
        {
            var dayTro = _phongService.getDayTroDTO();
            return Ok(dayTro);
        }

        [HttpGet("get-all-phong")]
        public IActionResult GetAllPhong()
        {
            var phong = _phongService.GetallPhong();
            return Ok(phong);
        }

        [HttpPost("add-phong")]
        public IActionResult AddPhong([FromBody] PhongDTO phongDTO)
        {
            var phong = _phongService.AddPhong(phongDTO);
            return StatusCode(200, phong);
        }
        [HttpPut("update-phong")]
        public IActionResult UpdatePhong([FromQuery] int? id, [FromBody] PhongDTO phongDTO)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var phong = _phongService.UpdatePhong(id.Value, phongDTO);
                    return StatusCode(202, phong);
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-phong")]
        public IActionResult DeletePhong([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var phong = _phongService.DeletePhong(id.Value);
                    return Ok(new { Message = $"Xóa phòng {phong.tenPhong} thành công" });
                }
                return BadRequest("Vui lòng nhập lại Id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
