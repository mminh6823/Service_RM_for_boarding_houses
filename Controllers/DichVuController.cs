using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private DichVuService _dichVuService { get; set; }

        public DichVuController(DichVuService dichVuService)
        {
            _dichVuService = dichVuService;
        }

        [HttpGet("get-dich-vu")]
        public IActionResult GetDichVu()
        {
            try
            {
                var getList = _dichVuService.GetListDichVu();
                return Ok(getList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-dich-vu-id")]
        public IActionResult GetDichVubyId([FromQuery] int? id)
        {
            try
            {
                var getDichvubyid = _dichVuService.GetDichVubyID(id);
                return Ok(getDichvubyid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-dich-vu")]
        public IActionResult AddDichVu(DichVuDTO dichVuDTO)
        {
            try
            {
                var addDichVu = _dichVuService.AddDichVu(dichVuDTO);
                return Ok(new { Message = $"Thêm thành công dịch vụ {addDichVu.tenDichVu}" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-dich-vu")]
        public IActionResult UpdateDichVu([FromQuery] int id, [FromBody] DichVuDTO dichVuDTO)
        {
            try
            {
                var upDateDV = _dichVuService.UpdateDichVu(id, dichVuDTO);
                return Ok(new { Message = $"Cập nhật dịch vụ {upDateDV.tenDichVu} thành công! " });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete-dich-vu")]
        public IActionResult DeleteDichVu([FromQuery] int? id)
        {
            try
            {
               _dichVuService.DeleteDichVu(id);
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
