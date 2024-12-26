using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using Service_PhongTro.Service;
using System.Drawing.Printing;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiThueController : ControllerBase
    {
        private readonly NguoiThueService _nguoiThueService;

        public NguoiThueController(NguoiThueService nguoiThueService)
        {
            _nguoiThueService = nguoiThueService;
        }
        [HttpGet("get-all-nguoithue")]
        public IActionResult GetAllNguoiThue()
        {
            var nguoithue = _nguoiThueService.GetAllNguoiThue();
            return Ok(nguoithue);
        }

        [HttpPost("create-nguoithue")]
        public async Task<IActionResult> CreateNguoiThue([FromForm] NguoiThueDTO nguoiThueDTO, [FromForm] ImageUpload imageModel)
        {
            try
            {
                if (imageModel.AnhDaiDien == null || imageModel.MatTruocCCCD == null || imageModel.MatSauCMND == null)
                {
                    return BadRequest("All image files must be provided.");
                }

                var result = await _nguoiThueService.CreateNguoiThue(nguoiThueDTO, imageModel.AnhDaiDien, imageModel.MatTruocCCCD, imageModel.MatSauCMND);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("delete-nguoithue")]
        public IActionResult DeleteNguoiThue([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue && id != 0) 
                {
                   _nguoiThueService.DeleteNguoiThue(id.Value);
                    return StatusCode(200,$"Xóa thành công người thuê có id = {id}");
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
