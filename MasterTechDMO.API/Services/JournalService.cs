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
    public class JournalService
    {
        private IJournalRepo _repo;

        public JournalService(MTDMOContext context)
        {
            _repo = new JournalRepo(context);
        }

        public async Task<APICallResponse<List<Journal>>> GetByDate(DateTime searchDT)
        {
            return await _repo.GetByDate(searchDT);
        }

        public async Task<APICallResponse<bool>> SaveOrUpdate(Journal journal)
        {
            return await _repo.SaveOrUpdate(journal);
        }

        public async Task<APICallResponse<List<Journal>>> GetAll(Guid userId)
        {
            return await _repo.GetAll(userId);
        }

        public async Task<APICallResponse<Journal>> GetById(Guid id)
        {
            return await _repo.GetByID(id);
        }

        public async Task<APICallResponse<bool>> Remove(Guid id)
        {
            var dbJournal = await _repo.GetByID(id);
            if (dbJournal != null)
            {
                dbJournal.Respose.IsRemoved = true;
                return await _repo.SaveOrUpdate(dbJournal.Respose);
            }

            var response = new APICallResponse<bool>();
            response.IsSuccess = dbJournal.IsSuccess;
            response.Status = dbJournal.Status;
            if (response.IsSuccess && response.Respose != null)
            {
                response.Message = dbJournal.Message;
                response.Respose = true;
            }
            else
            {
                response.Message.Add("No Journal found.");
                response.Respose = false;
            }
            return response;
        }

    }
}
