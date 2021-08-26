using MasterTechDMO.API.Models;
using mtsDMO.Context.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Repos
{
    public interface IJournalRepo
    {
        Task<APICallResponse<List<Journal>>> GetByDate(DateTime searchDT);
        Task<APICallResponse<List<Journal>>> GetAll(Guid userId);
        Task<APICallResponse<bool>> SaveOrUpdate(Journal journal);
        Task<APICallResponse<Journal>> GetByID(Guid id);
    }
}
