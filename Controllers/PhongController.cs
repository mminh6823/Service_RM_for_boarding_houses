using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var loaiPhong = _phongService.GetLoaiPhong();
            return Ok(loaiPhong);
        }
    }
}
