using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Models;
using mtsDMO.Context.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Repos
{
    public class JournalRepo : IJournalRepo
    {

        MTDMOContext _context;
        public JournalRepo(MTDMOContext context)
        {
            _context = context;
        }
        public async Task<APICallResponse<List<Journal>>> GetByDate(DateTime searchDT)
        {
            APICallResponse<List<Journal>> response = new APICallResponse<List<Journal>>();
            try
            {
                var data = _context.DMOJournals.Where(x => x.InsDT.Date == searchDT.Date).ToList();
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

        public async Task<APICallResponse<bool>> SaveOrUpdate(Journal journal)
        {
            APICallResponse<bool> response = new APICallResponse<bool>();
            try
            {
                var dbJournal = _context.DMOJournals.Find(journal.Id);
                if (dbJournal == null)
                {
                    _context.DMOJournals.Add(journal);
                }
                else
                {
                    dbJournal.Comment = journal.Comment;
                    dbJournal.IsRemoved = journal.IsRemoved;
                    dbJournal.UpdDT = DateTime.UtcNow.Date;
                }
                _context.SaveChanges();

                response.Message.Add($"Journal update successfully.");
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

        public async Task<APICallResponse<List<Journal>>> GetAll(Guid userId)
        {
            APICallResponse<List<Journal>> response = new APICallResponse<List<Journal>>();
            try
            {
                var data = _context.DMOJournals.Where(x => x.UserId == userId && x.IsRemoved == false).ToList();
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

        public async Task<APICallResponse<Journal>> GetByID(Guid id)
        {
            APICallResponse<Journal> response = new APICallResponse<Journal>();
            try
            {
                var data = _context.DMOJournals.Where(x=>x.Id == id && x.IsRemoved == false).FirstOrDefault();
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
