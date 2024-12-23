using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DienNuocController : ControllerBase
    {
        private readonly DienNuocService _dienNuocService;

        public DienNuocController(DienNuocService dienNuocService)
        {
            _dienNuocService = dienNuocService;
        }
        [HttpGet("get-list-ten-phong")]
        public IActionResult getListPhong()
        {
            var _phong = _dienNuocService.GetListTenphong();
            return Ok(_phong);
        }
        [HttpGet("get-dien-nuoc")]
        public IActionResult GetDienNuoc()
        {
            try
            {
                var _dienNuoc = _dienNuocService.GetDienNuoc();
                return _dienNuoc != null ? Ok(_dienNuoc) : BadRequest("Không có dữ liệu");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-dien-nuoc-id")]
        public IActionResult GetDienNuocId([FromQuery] int id)
        {
            try
            {
                var _dienNuoc = _dienNuocService.GetDienNuocId(id);
                return _dienNuoc != null ? Ok(_dienNuoc) : BadRequest("Không có dữ liệu");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("add-dien-nuoc")]
        public IActionResult AddDienNuoc([FromBody] DienNuocDTO dienNuocDTO)
        {
            try
            {
                var _dienNuoc = _dienNuocService.AddDienNuoc(dienNuocDTO);

                return _dienNuoc != null ? Ok(_dienNuoc) : BadRequest("Thêm thất bại");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-dien-nuoc")]
        public IActionResult DeleteDienNuoc([FromQuery] int id)
        {
            try
            {
                var _dienNuoc = _dienNuocService.DeleteDienNuoc(id);
                return _dienNuoc != null ? Ok($"Xóa thành công dịch vụ điện nước có id {_dienNuoc.Id}") : BadRequest("Xóa thất bại");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
