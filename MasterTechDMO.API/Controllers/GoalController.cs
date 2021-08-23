using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Services;
using Microsoft.AspNetCore.Mvc;
using mtsDMO.Context.Utility;
using System;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GoalController : Controller
    {

        private GoalService _service;

        public GoalController(MTDMOContext context)
        {
            _service = new GoalService(context);
        }

        [HttpGet("getByDate/{searchDT}")]
        public async Task<IActionResult> GetByDate(DateTime searchDT)
        {
            return Ok(await _service.GetByDate(searchDT));
        }

        [HttpPost("addGoal")]
        public async Task<IActionResult> SaveGoal(Goals goal)
        {
            return Ok(await _service.SaveOrUpdate(goal));
        }

        [HttpPost("updateGoal")]
        public async Task<IActionResult> UpdateGoal(Goals goal)
        {
            return Ok(await _service.SaveOrUpdate(goal));
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
