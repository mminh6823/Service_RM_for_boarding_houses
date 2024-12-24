using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly TaiKhoanService _taikhoanService;

        public TaiKhoanController(TaiKhoanService taikhoanService)
        {
            _taikhoanService = taikhoanService;
        }
        [HttpGet("get-all-taikhoan")]
        public IActionResult GetAllTaiKhoan()
        {
            var taikhoan = _taikhoanService.GetTaiKhoans();
            return Ok(taikhoan);
        }
        [HttpGet("get-taikhoan")]
        public IActionResult GetTaiKhoanId([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var taikhoan = _taikhoanService.GetTaiKhoanId(id.Value);
                    return Ok(taikhoan);
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-taikhoan")]
        public IActionResult UpdateTaiKhoan([FromQuery] int? id, [FromBody] TaiKhoanDTO taikhoanDTO)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var taikhoan = _taikhoanService.UpdateTaiKhoanId(id.Value, taikhoanDTO);
                    return Ok(taikhoan);
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-taikhoan")]
        public IActionResult DeleteTaiKhoan([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var taikhoan = _taikhoanService.DeleteTaiKhoanId(id.Value);
                    return Ok(taikhoan);
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
