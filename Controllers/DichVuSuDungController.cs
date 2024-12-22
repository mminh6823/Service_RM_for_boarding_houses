using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using Service_PhongTro.Service;
using System.Net.WebSockets;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuSuDungController : ControllerBase
    {
        private readonly DichVuSuDungService _service;

        public DichVuSuDungController(DichVuSuDungService service)
        {
            _service = service;
        }

        [HttpGet("get-dich-vu-sd-phong")]
        public IActionResult GetAllList()
        {
            try
            {
                var listdichvuphong = _service.getAllDichVuPhong();
                return Ok(listdichvuphong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet("get-dich-vu-sd")]
        public IActionResult GetDichVuSd()
        {
            try
            {
                var listdichvusd = _service.getAllDichVu();
                return Ok(listdichvusd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-detail-dich-vu-sd")]
        public IActionResult GetAllDichVuSd()
        {
            try
            {
                var listalldichvusd = _service.getDichVuSuDung();
                return Ok(listalldichvusd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-dich-vu-sd")]
        public IActionResult AddDichVuSuDung([FromBody]GetDichVuSuDungDTO dichVuSuDungDTO)
        {
            try
            {
                var addDichVuSd = _service.AddDichVuSuDung(dichVuSuDungDTO);
                return Ok("Thêm thành công! Trở về get list detail để xem chi tiết! ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
