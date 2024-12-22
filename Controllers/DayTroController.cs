using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_PhongTro.DTOs;
using Service_PhongTro.Models;
using Service_PhongTro.Service;

namespace Service_PhongTro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayTroController : ControllerBase
    {
        private readonly DayTroService _dayTroService;

        public DayTroController(DayTroService dayTroService)
        {
            _dayTroService = dayTroService;
        }

        [HttpGet("get-daytro-list")]
        public IActionResult getdayTro()
        {
            try
            {
                var listdaytro = _dayTroService.GetDayTroList();
                return Ok(listdaytro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-daytro-by-id")]
        public IActionResult getDayTrobyID([FromQuery] int id)
        {
            try
            {
                var getdaytrobyID = _dayTroService.GetDayTroByID(id);
                return Ok(getdaytrobyID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-daytro")]
        public IActionResult addDayTro([FromBody] DayTroDTO dayTroDTO)
        {
            try
            {
                var newDayTro = _dayTroService.AddDayTro(dayTroDTO);
                return Ok(new { Message = $"Thêm thành công {newDayTro.tenDayTro}" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-daytro")]
        public IActionResult UpdateDayTro([FromQuery] int id, [FromBody] DayTroDTO dayTroDTO)
        {
            try
            {
                var updatedaytro = _dayTroService.UpdateDayTro(id, dayTroDTO);
                return Ok(updatedaytro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("delete-daytro")]
        public IActionResult DeleteDayTro([FromQuery] int id)
        {
            try
            {
                _dayTroService.DeleteDayTro(id);
                return Ok("Xóa thành công! ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
