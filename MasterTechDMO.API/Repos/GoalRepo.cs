using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Models;
using mtsDMO.Context.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Repos
{
    public class GoalRepo : IGoalRepo
    {

        MTDMOContext _context;
        public GoalRepo(MTDMOContext context)
        {
            _context = context;
        }
        public async Task<APICallResponse<List<Goals>>> GetByDate(DateTime searchDT)
        {
            APICallResponse<List<Goals>> response = new APICallResponse<List<Goals>>();
            try
            {
                var data = _context.DMOGoal.Where(x => x.InsDT.Date == searchDT.Date).ToList();
                response.Message.Add($"{data.Count} goals found for {searchDT.Date}");
                response.IsSuccess = true;
                response.Respose = data;
                response.Status = "Success";

            }
            catch (Exception Ex)
            {
                response.Message.Add(Ex.Message);
                response.IsSuccess = false;
                response.Status = "Error";
            }
            return response;
        }

        public async Task<APICallResponse<bool>> SaveOrUpdate(Goals goal)
        {
            APICallResponse<bool> response = new APICallResponse<bool>();
            try
            {
                var dbGoal = _context.DMOGoal.Find(goal.Id);
                if (dbGoal == null)
                {
                    _context.DMOGoal.Add(goal);
                }
                else
                {
                    dbGoal.IsRemoved = goal.IsRemoved;
                    dbGoal.Count = goal.Count;
                    dbGoal.Name = goal.Name;
                    dbGoal.UpdDT = DateTime.UtcNow.Date;
                }
                _context.SaveChanges();

                response.Message.Add($"{goal.Name} update successfully.");
                response.IsSuccess = true;
                response.Respose = true;
                response.Status = "Success";

            }
            catch (Exception Ex)
            {
                response.Message.Add(Ex.Message);
                response.IsSuccess = false;
                response.Status = "Error";
            }
            return response;
        }

        public async Task<APICallResponse<List<Goals>>> GetAll(Guid userId)
        {
            APICallResponse<List<Goals>> response = new APICallResponse<List<Goals>>();
            try
            {
                var data = _context.DMOGoal.Where(x => x.UserId == userId).ToList();
                response.Message.Add($"{data.Count} goals found.");
                response.IsSuccess = true;
                response.Respose = data;
                response.Status = "Success";

            }
            catch (Exception Ex)
            {
                response.Message.Add(Ex.Message);
                response.IsSuccess = false;
                response.Status = "Error";
            }
            return response;
        }

        public async Task<APICallResponse<Goals>> GetByID(Guid id)
        {
            APICallResponse<Goals> response = new APICallResponse<Goals>();
            try
            {
                var data = _context.DMOGoal.Find(id);
                if (data == null)
                {
                    response.Message.Add("Oops! No Goal Found");
                }
                else
                {
                    response.Respose = data;
                }
                response.IsSuccess = true;
                response.Status = "Success";

            }
            catch (Exception Ex)
            {
                response.Message.Add(Ex.Message);
                response.IsSuccess = false;
                response.Status = "Error";
            }
            return response;
        }
    }
}
