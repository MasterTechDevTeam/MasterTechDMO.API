using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Models;
using MasterTechDMO.API.Repos;
using mtsDMO.Context.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Services
{
    public class GoalService
    {
        private IGoalRepo _repo;

        public GoalService(MTDMOContext context)
        {
            _repo = new GoalRepo(context);
        }

        public async Task<APICallResponse<List<Goals>>> GetByDate(DateTime searchDT)
        {
            return await _repo.GetByDate(searchDT);
        }

        public async Task<APICallResponse<bool>> SaveOrUpdate(Goals goal)
        {
            return await _repo.SaveOrUpdate(goal);
        }

        public async Task<APICallResponse<List<Goals>>> GetAll(Guid userId)
        {
            return await _repo.GetAll(userId);
        }

        public async Task<APICallResponse<Goals>> GetById(Guid id)
        {
            return await _repo.GetByID(id);
        }

        public async Task<APICallResponse<bool>> Remove(Guid id)
        {
            var dbGoal = await _repo.GetByID(id);
            if (dbGoal != null)
            {
                dbGoal.Respose.IsRemoved = true;
                return await _repo.SaveOrUpdate(dbGoal.Respose);
            }

            var response = new APICallResponse<bool>();
            response.IsSuccess = dbGoal.IsSuccess;
            response.Status = dbGoal.Status;
            if (response.IsSuccess && response.Respose != null)
            {
                response.Message = dbGoal.Message;
                response.Respose = true;
            }
            else
            {
                response.Message.Add("No goal found.");
                response.Respose = false;
            }
            return response;
        }

    }
}
