using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Repos
{
    public interface IConnectionRepo
    {
        Task<APICallResponse<List<DMOUserFriendList>>> GetFriendListAsync(Guid userId);

        Task<APICallResponse<DMOUserFriendList>> GetFriendDataByEmailAsync(Guid userId, string friendEmailId);

        Task<APICallResponse<bool>> AddOrUpdateFriendDataAsync(DMOUserFriendList friendData);

        Task<APICallResponse<bool>> RemoveFriendAsync(Guid userId, string username);
    }
}
