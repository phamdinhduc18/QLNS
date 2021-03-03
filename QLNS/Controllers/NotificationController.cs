using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNS.Data;
using QLNS.DTOs;
using QLNS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLNS.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly DBContext _context;

        public NotificationController(INotificationService service, DBContext context)
        {
            _service = service;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] NotificationDTO newNotification)
        {
            return Ok(await _service.AddNotification(newNotification));
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Notifications>>> GetEmployees()
        {
            return await _context.Notifications.ToListAsync();
        }

        [HttpPost("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteNotification(id);
            if (result == null) return Ok(new { isSuccess = false, message = "Delete faild!" });
            return Ok(new { isSuccess = true, message = "Successfully!" });
        }

    }
}
