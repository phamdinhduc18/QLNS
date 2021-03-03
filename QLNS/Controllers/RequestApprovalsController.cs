using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.DTOs;
using QLNS.Models;
using QLNS.Services;

namespace QLNS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestApprovalsController : Controller
    {
        private readonly DBContext _context;
        private readonly IRequestApprovalService _service;

        public RequestApprovalsController(DBContext context, IRequestApprovalService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<ActionResult<List<RequestApprovals>>> GetAll()
        {
            await _service.UpdateStateAsync();
            return await _context.RequestApprovals.ToListAsync();
        }

        // GET: RequestApprovals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestApprovals = await _context.RequestApprovals
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestApprovals == null)
            {
                return NotFound();
            }

            return View(requestApprovals);
        }

        // POST: RequestApprovals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Staff")]

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RequestApprovalDTO radto)
        {

            return Ok(await _service.AddRqApproval(radto));
        }

        //duyệt
        [HttpPost("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(int id, RequestApprovalDTO requestDTO)
        {
            var getid = _context.RequestApprovals.Find(id);                                      //find là 1 cai. firstorderdetail trả nhiều, lấy 1 cái đầu
            if (getid.Status == 0)
            {
                getid.Status = 1;
            }
            else
            {
                getid.Status = -1;
            }
            //if(getid.Status == -1)
            //{
            //    getid.Status = 1;
            //}
            getid.RejectedReason = requestDTO.RejectedReason;
            var result = _context.SaveChanges();
            return Ok(result);
        }

        //Deny
        [HttpPost("updatedeny/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Updatedeny(int id, RequestApprovalDTO requestDTO)
        {
            var getid = _context.RequestApprovals.Find(id);                                      //find là 1 cai. firstorderdetail trả nhiều, lấy 1 cái đầu
            if (getid.Status == 0)
                getid.Status = -1;
            getid.RejectedReason = requestDTO.RejectedReason;
            var result = _context.SaveChanges();
            return Ok(result);
        }

        // POST: RequestApprovals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // GET: RequestApprovals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestApprovals = await _context.RequestApprovals
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestApprovals == null)
            {
                return NotFound();
            }

            return View(requestApprovals);
        }

        // POST: RequestApprovals/Delete/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestApprovals = await _context.RequestApprovals.FindAsync(id);
            _context.RequestApprovals.Remove(requestApprovals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestApprovalsExists(int id)
        {
            return _context.RequestApprovals.Any(e => e.Id == id);
        }
    }
}
