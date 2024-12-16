using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DominModels;
using ViewModel.ViewModels;
using ViewModel.DTOS;
using BLService.LogerService;

namespace LoggingSystemTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogerController : ControllerBase
    {


        private readonly ILogerService _logService;

        public LogerController(ILogerService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LogViewModel>>> GetLogs()
        {
            return Ok(await _logService.GetAllLogsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogViewModel>> GetLogById(int id)
        {
            var log = await _logService.GetLogByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogDTO logDto)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            int id =await _logService.CreateLogAsync(logDto);
            if (id == 0) {
                return BadRequest("Failed to create the log.");
            }
            return CreatedAtAction(nameof(GetLogById), new { id = id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLog(int id, [FromBody] LogDTO logDto)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            try
            {           
                await _logService.UpdateLogAsync(id, logDto);
                return NoContent();

            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            await _logService.DeleteLogAsync(id);
            return NoContent();
        }
    }
}
