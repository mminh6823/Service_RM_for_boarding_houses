using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuePhongController : ControllerBase
    {
        private readonly ThuePhongService _thuePhongService;

        public ThuePhongController(ThuePhongService thuePhongService)
        {
            _thuePhongService = thuePhongService;
        }
        [HttpGet("get-all-thuephong-phong")]
        public IActionResult GetAllPhongThue()
        {
            var _phong = _thuePhongService.GetAllPhongVM();
            return Ok(_phong);
        }

        [HttpGet("get-all-thuephong-nguoithue")]
        public IActionResult GetAllNguoiThue()
        {
            var _nguoithue = _thuePhongService.GetAllNguoiThueVM();
            return Ok(_nguoithue);
        }

        [HttpGet("get-all-thuephong-loaiphong")]
        public IActionResult GetAllLoaiPhong()
        {
            var _loaiphong = _thuePhongService.GetAllLoaiPhong();
            return Ok(_loaiphong);
        }

        [HttpGet("get-thuephong-list")]
        public IActionResult GetThuePhong()
        {
            var _thuephong = _thuePhongService.GetThuePhongs();
            return Ok(_thuephong);
        }
        [HttpGet("get-all-thuephong-diennuoc")]
        public IActionResult GetAllDienNuoc()
        {
            var _diennuoc = _thuePhongService.GetAlldienNuocVM();
            return Ok(_diennuoc);
        }
        [HttpGet("get-all-thuephong-dichvu")]
        public IActionResult GetAllDichVu()
        {
            var _dichvu = _thuePhongService.GetAllDichVuSuDungVM();
            return Ok(_dichvu);
        }
        [HttpGet("tinh-tong-tien")]
        public ActionResult<decimal> TinhTongTien([FromQuery] int thuePhongId)
        {
            try
            {
                var tongTien =  _thuePhongService.TinhTongTien(thuePhongId);
                return Ok(tongTien);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi tính tổng tiền: {ex.Message}");
            }
        }

        [HttpPost("add-thuephong")]
        public IActionResult CreateThuePhong([FromBody] ThuePhongDTO thuePhongDTO)
        {
            try
            {
                var _thuephong = _thuePhongService.AddThuePhong(thuePhongDTO);
                if (_thuephong != null)
                {
                    return Ok(_thuephong);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-thuephong-id")]
        public async Task<IActionResult> UpdateThuePhongId(int thuephongId, [FromBody] ThuePhongDTO thuePhongDTO)
        {
            try
            {
                var _thuephong = await Task.Run(() => _thuePhongService.UpdateThuePhongId(thuephongId, thuePhongDTO));
                if (_thuephong != null)
                {
                    return Ok(_thuephong);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-thuephong-id")]
        public async Task<IActionResult> DeleteThuePhongId([FromQuery]int id)
        {
            try
            {
                await _thuePhongService.DeleteThuePhongId(id);
                return Ok("Xóa Thành Công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa thuê phòng: {ex.Message}");
            }
        }

    }
}
