using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly ThongBaoService _thongBaoService;

        public ThongBaoController(ThongBaoService thongBaoService)
        {
            _thongBaoService = thongBaoService;
        }
        [HttpGet("get-all-thongbao")]
        public IActionResult GetAllThongBao()
        {
            var thongbao = _thongBaoService.GetallThongBao();
            return Ok(thongbao);
        }
        [HttpGet("get-thongbao")]
        public IActionResult GetThongBaoId([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var thongbao = _thongBaoService.GetThongBaoAsync(id.Value);
                    return Ok(thongbao);
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-thongbao")]
        public IActionResult AddThongBao([FromBody] ThongBaoDTO thongBaoDTO)
        {
            try
            {
                var thongbao = _thongBaoService.CreateThongBaoAsync(thongBaoDTO);
                return Ok(thongbao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-thongbao")]
        public IActionResult UpdateThongBao([FromQuery] int? id, [FromBody] ThongBaoDTO thongBaoDTO)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var thongbao = _thongBaoService.UpdateThongBaoAsync(id.Value, thongBaoDTO);
                    return Ok(thongbao);
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-thongbao")]
        public IActionResult DeleteThongBao([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var thongbao = _thongBaoService.DeleteThongBaoAsync(id.Value);
                    if (thongbao != null)
                    {
                        return Ok($"Xóa thành công thông báo có ID = {thongbao.Id}");
                    }
                    return NotFound("Thông báo không tồn tại");
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
