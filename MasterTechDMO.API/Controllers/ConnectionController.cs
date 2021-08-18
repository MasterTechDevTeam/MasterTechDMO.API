using System;
using System.Threading.Tasks;
using MasterTechDMO.API.Areas.Identity.Data;
using MasterTechDMO.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mtsDMO.Context.Utility;

namespace MasterTechDMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ConnectionController : ControllerBase
    {
        private ConnectionServices _friendSerivce;
        public ConnectionController(
             MTDMOContext context)
        {
            _friendSerivce = new ConnectionServices(context);
        }

        /// <summary>
        /// Return list of Connection/Contacts
        /// </summary>
        /// <param name="userId">userId of User</param>
        /// <returns>Return object of Ok(200)</returns>
        [HttpGet]
        [Route("getConnection/{userId}")]
        public async Task<IActionResult> GetFriendListAsync(Guid userId)
        {
            return Ok(await _friendSerivce.GetFriendListAsync(userId));
        }

        /// <summary>
        /// Retunr the details of Connections/Contact
        /// </summary>
        /// <param name="userId">userId of Requestd user</param>
        /// <param name="friendEmailId">emailId of frined for find the details</param>
        /// <returns>Return object of Ok(200)</returns>
        [HttpGet]
        [Route("getConnectionData/{userId}/{friendEmailId}")]
        public async Task<IActionResult> GetFriendDataByEmailAsync(Guid userId,string friendEmailId)
        {
            return Ok(await _friendSerivce.GetFriendDataByEmailAsync(userId,friendEmailId));
        }

        /// <summary>
        /// Update the Connections/Contact details
        /// </summary>
        /// <param name="friendData">Object of UserFriendData Type</param>
        /// <returns>Return object of Ok(200)</returns>
        [HttpPost]
        [Route("updateConnection")]
        public async Task<IActionResult> UpdateFriendDataAsync(Connections friendData)
        {
            return Ok(await _friendSerivce.AddOrUpdateFriendDataAsync(friendData));
        }

        /// <summary>
        /// Add Connections/Contact to user
        /// </summary>
        /// <param name="friendData">Object of UserFriendData</param>
        /// <returns>Return object of Ok(200)</returns>
        [HttpPost]
        [Route("addConnectionData")]
        public async Task<IActionResult> AddFriendDataAsync(Connections friendData)
        {
            return Ok(await _friendSerivce.AddOrUpdateFriendDataAsync(friendData));
        }

        /// <summary>
        /// Remove Connections/Contact from the contact list of user
        /// </summary>
        /// <param name="userId">userId of requestd user</param>
        /// <param name="username">emailId of Connections/Contact you want to remove</param>
        /// <returns></returns>
        [HttpGet]
        [Route("removeConnection/{userId}/{username}")]
        public async Task<IActionResult> RemoveFriendAsync(Guid userId,string username)
        {
            return Ok(await _friendSerivce.RemoveFriendAsync(userId,username));
        }
    }
}
