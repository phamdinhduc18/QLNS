using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using QLNS.Data;
using QLNS.DTOs;
using QLNS.Helpers;
using QLNS.Helpers.Extensions;
using QLNS.Models;
using QLNS.Services;

namespace QLNS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMailService _mailService;
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeesController(DBContext context, IEmployeeService service, IMailService mailService, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mailService = mailService;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        //GetBirthDay
        //GET: api
        [HttpGet("GetBirthDay")]
       public async Task<IActionResult> GetBirthdayEmployee()
        {
            List<Employees> result = await _context.Employees.ToListAsync();
            var resultDTO = _mapper.Map<List<EmployeeBirthdayDTO>>(result);
            return Ok(resultDTO);
        }

        //Get Listbirthday current day
        [HttpGet("BirthDayCurrent")]
        public IActionResult BirthDay()
        {
            List<Employees> result = _context.Employees.ToList();
            var resultDTO = _mapper.Map<List<EmployeeBirthdayDTO>>(result);
            var list = resultDTO.Select(x => new { x.EmployeeId, x.FullName, x.DateOfBirth, x.ManagerId }).Where(x => x.DateOfBirth.Day==DateTime.Now.Day&& x.DateOfBirth.Month==DateTime.Now.Month);
            return Ok(list);
        }

        //Get listbirthday current month
        [HttpGet("BirthDayMonthCurrent")]
        public IActionResult BirthDayMonth()
        {
            List<Employees> result = _context.Employees.ToList();
            var resultDTO = _mapper.Map<List<EmployeeBirthdayDTO>>(result);
            var list = resultDTO.Select(x => new { x.EmployeeId, x.FullName, x.DateOfBirth, x.ManagerId }).Where(x => x.DateOfBirth.Month == DateTime.Now.Month);
            return Ok(list);
        }

        //Get listbirthday month
        [HttpGet("BirthDayMonth")]
        public IActionResult BirthMonth(int month)
        {
            List<Employees> result = _context.Employees.ToList();
            var resultDTO = _mapper.Map<List<EmployeeBirthdayDTO>>(result);
            var list = resultDTO.Select(x => new { x.EmployeeId, x.FullName, x.DateOfBirth, x.ManagerId }).Where(x => x.DateOfBirth.Month == month);
            return Ok(list);
        }


        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        [Route("test")]
        public ActionResult<bool> TestMail()
        {
            Convert.ToChar(0);
            return _mailService.SendMailToUser(new Employees { Email = "vinhtran01289@gmail.com", FullName = "Vinh" }, Password.Random());
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(int id)
        {
            var result = await _service.GetAsync(id);
            if (result == null) return BadRequest();
            return Ok(result);

        }

        // PUT: api/Employees/update/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutEmployees(int id, Employees employees)
        {
            employees.EmployeeId = id;
            Employees ep = _context.Employees.Find(id);
            ep.FullName = employees.FullName;
            ep.Email = employees.Email;
            ep.DateOfBirth = employees.DateOfBirth;
            ep.Gender = employees.Gender;
            ep.PhoneNumber = employees.PhoneNumber;
            ep.StartDate = employees.StartDate;
            ep.DepartmentId = employees.DepartmentId;
            ep.RoleId = employees.RoleId;
            ep.ManagerId = employees.ManagerId;

            var result = await _service.UpdateAsync(id, ep);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<ActionResult> PostEmployees(CreateEmployeeDTO newEmployee)
        {
            return Ok(await _service.AddEmployee(newEmployee));
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employees>> DeleteEmployees(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();

            return employees;
        }

        [Authorize(Roles = "Admin")] //1: Admin
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(JObject objectForm)
        {
            var id = objectForm.Value<int>("id".ToLower());
            var response = await _service.ResetPasswordByAdmin(id);
            if (response == null)
                return NotFound(new { isSuccess = false, message = "User not found" });

            var user = response.Item1;
            var newPassword = response.Item2;

            var isSendMailSuccess = _mailService.SendMailToUser(user, newPassword);

            return Ok(new { isSuccess = isSendMailSuccess, message = $"success{(isSendMailSuccess ? "!!!" : ", but can't send mail!!!")}" });

        }

        [Authorize(Roles = "Staff")] //5: Staff
        [HttpPost("update-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangPasswordDTO dto)
        {

            var id = Request.GetId();
            // TODO:...
            var result = await _service.ChangePassword(dto);
            switch (result)
            {
                case -1:
                    return StatusCode(400, "User is not found!");
                case 0:
                    return StatusCode(400, "Password is incorrect!");
                default:
                    return Ok();
            }
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
