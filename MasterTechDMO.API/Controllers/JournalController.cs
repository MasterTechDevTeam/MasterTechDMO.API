using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtsDMO.Context.Utility;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class JournalController : Controller
    {

        private JournalService _service;

        public JournalController(MTDMOContext context)
        {
            _service = new JournalService(context);
        }

        [HttpGet("getByDate/{searchDT}")]
        public async Task<IActionResult> GetByDate(DateTime searchDT)
        {
            return Ok(await _service.GetByDate(searchDT));
        }

        [HttpPost("addJournal")]
        public async Task<IActionResult> SaveJournal(Journal journal)
        {
            return Ok(await _service.SaveOrUpdate(journal));
        }

        [HttpPost("updateJournal")]
        public async Task<IActionResult> UpdateJournal(Journal journal)
        {
            return Ok(await _service.SaveOrUpdate(journal));
        }

        [HttpGet("getAll/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            return Ok(await _service.GetAll(userId));
        }

        [HttpGet("getById/{goalId}")]
        public async Task<IActionResult> GetById(Guid goalId)
        {
            return Ok(await _service.GetById(goalId));
        }

        [HttpGet("remove/{goalId}")]
        public async Task<IActionResult> Remove(Guid goalId)
        {
            return Ok(await _service.Remove(goalId));
        }

    }
}
