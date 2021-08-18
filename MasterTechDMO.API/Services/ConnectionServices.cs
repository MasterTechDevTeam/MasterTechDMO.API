using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Models;
using MasterTechDMO.API.Repos;
using mtsDMO.Context.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Services
{
    public class ConnectionServices
    {
        private IConnectionRepo _friendListRepo;

        public ConnectionServices(MTDMOContext context)
        {
            _friendListRepo = new ConnectionRepo(context);
        }

        public async Task<APICallResponse<List<Connections>>> GetFriendListAsync(Guid userId)
        {
            var callResponse = new APICallResponse<List<Connections>>();
            var dbFriendListCallResponse = await _friendListRepo.GetFriendListAsync(userId);

            if (dbFriendListCallResponse.Respose != null)
            {
                callResponse.Respose = new List<Connections>();
                foreach (var dbFriend in dbFriendListCallResponse.Respose)
                {
                    callResponse.Respose.Add(new Connections
                    {
                        EmailId = dbFriend.EmailId,
                        Id = dbFriend.Id,
                        Name = dbFriend.Name,
                        PhoneNumber = dbFriend.PhoneNumber,
                        UserId = dbFriend.UserId
                    });
                }
            }
            callResponse.IsSuccess = dbFriendListCallResponse.IsSuccess;
            callResponse.Message = dbFriendListCallResponse.Message;
            callResponse.Status = dbFriendListCallResponse.Status;
            return callResponse;
        }

        public async Task<APICallResponse<Connections>> GetFriendDataByEmailAsync(Guid userId, string friendEmailId)
        {
            var callResponse = new APICallResponse<Connections>();
            var dbFriendCallResponse = await _friendListRepo.GetFriendDataByEmailAsync(userId, friendEmailId);
            if (dbFriendCallResponse.Respose != null)
            {
                callResponse.Respose = new Connections
                {
                    EmailId = dbFriendCallResponse.Respose.EmailId,
                    Id = dbFriendCallResponse.Respose.Id,
                    Name = dbFriendCallResponse.Respose.Name,
                    PhoneNumber = dbFriendCallResponse.Respose.PhoneNumber,
                    UserId = dbFriendCallResponse.Respose.UserId
                };
            }
            callResponse.IsSuccess = dbFriendCallResponse.IsSuccess;
            callResponse.Message = dbFriendCallResponse.Message;
            callResponse.Status = dbFriendCallResponse.Status;
            return callResponse;
        }

        public async Task<APICallResponse<bool>> AddOrUpdateFriendDataAsync(Connections friendData)
        {
            var dbFriendData = new DMOUserFriendList
            {
                Id = friendData.Id,
                EmailId = friendData.EmailId,
                Name = friendData.Name,
                PhoneNumber = friendData.PhoneNumber,
                UserId = friendData.UserId
            };

            return await _friendListRepo.AddOrUpdateFriendDataAsync(dbFriendData);
        }

        public async Task<APICallResponse<bool>> RemoveFriendAsync(Guid userId,string username)
        {
            return await _friendListRepo.RemoveFriendAsync(userId, username);
        }

    }
}
