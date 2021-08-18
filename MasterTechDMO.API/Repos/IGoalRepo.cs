using MasterTechDMO.API.Models;
using mtsDMO.Context.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Repos
{
    public interface IGoalRepo
    {
        Task<APICallResponse<List<Goals>>> GetByDate(DateTime searchDT);
        Task<APICallResponse<List<Goals>>> GetAll(Guid userId);
        Task<APICallResponse<bool>> SaveOrUpdate(Goals goal);
        Task<APICallResponse<Goals>> GetByID(Guid id);
    }
}
