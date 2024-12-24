using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanNguoiDungController : ControllerBase
    {
        private readonly TaiKhoanNguoiDungService _taikhoannguoidungService;

        public TaiKhoanNguoiDungController(TaiKhoanNguoiDungService taikhoannguoidungService)
        {
            _taikhoannguoidungService = taikhoannguoidungService;
        }

        [HttpGet("get-all-nguoithue")]
        public IActionResult GetAllNguoiThue()
        {
            var nguoithue = _taikhoannguoidungService.GetAllNguoiThue();
            return Ok(nguoithue);
        }
        [HttpGet("get-all-taikhoannguoidung")]
        public IActionResult GetAllTaiKhoanNguoiDung()
        {
            var taikhoannguoidung = _taikhoannguoidungService.GetTaikhoanNguoiDungs();
            return Ok(taikhoannguoidung);
        }
        [HttpGet("get-taikhoannguoidung")]
        public IActionResult GetTaiKhoanNguoiDungId([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var taikhoannguoidung = _taikhoannguoidungService.GetTaikhoanNguoiDungId(id.Value);
                    return Ok(taikhoannguoidung);
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-taikhoannguoidung")]
        public IActionResult AddTaiKhoanNguoiDung([FromBody] TaiKhoanNguoiDungDTO taiKhoanNguoiDungDTO)
        {
            try
            { var addtaikhoan = _taikhoannguoidungService.AddTaiKhoanNguoiDung(taiKhoanNguoiDungDTO);
                return Ok(addtaikhoan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-taikhoannguoidung")]
        public IActionResult UpdateTaiKhoanNguoiDungId([FromQuery] int? id, [FromBody] TaiKhoanNguoiDungDTO taiKhoanNguoiDungDTO)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var taikhoannguoidung = _taikhoannguoidungService.UpdateTaiKhoanNguoiDungId(id.Value, taiKhoanNguoiDungDTO);
                    return StatusCode(202, taikhoannguoidung);
                }
                return BadRequest("Vui lòng nhập lại id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-taikhoannguoidung")]
        public IActionResult DeleteTaiKhoanNguoiDungId([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var taikhoannguoidung = _taikhoannguoidungService.DeleteTaiKhoanNguoidungId(id.Value);
                    return Ok($"Xóa thành công tài khoản có ID = {taikhoannguoidung.Id}");
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
