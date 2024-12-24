using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        private readonly LoaiPhongService _loaiPhongService;

        public LoaiPhongController(LoaiPhongService loaiPhongService)
        {
            _loaiPhongService = loaiPhongService;
        }

        [HttpGet("get-loai-phong")]
        public IActionResult GetLoaiPhong()
        {
            var loaiPhong = _loaiPhongService.GetLoaiPhong();
            return Ok(loaiPhong);
        }
        [HttpGet("get-loai-phong-by-id")]
        public IActionResult GetLoaiPhongbyID([FromQuery] int id)
        {
            var loaiPhong = _loaiPhongService.GetLoaiPhongbyID(id);
            return Ok(loaiPhong);
        }
        [HttpPost("add-loai-phong")]
        public IActionResult AddLoaiPhong([FromBody] LoaiPhongDTO loaiPhongDTO)
        {
            var loaiPhong = _loaiPhongService.AddLoaiPhong(loaiPhongDTO);
            return Ok(loaiPhong);
        }
        [HttpPut("update-loai-phong")]
        public IActionResult UpdateLoaiPhong([FromQuery] int id, [FromBody] LoaiPhongDTO loaiPhongDTO)
        {
            var loaiPhong = _loaiPhongService.UpdateLoaiPhong(id, loaiPhongDTO);
            return Ok(loaiPhong);
        }
        [HttpDelete("delete-loai-phong")]
        public IActionResult DeleteLoaiPhong([FromQuery] int id)
        {
            var loaiPhong = _loaiPhongService.DeleteLoaiPhong(id);
            return Ok(new {Message = $"Xóa phòng {loaiPhong.tenLoaiPhong} thành công"});
        }

    }
}
