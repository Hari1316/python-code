using AutoMapper;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using MSCMS_BusinessLayer;
using MSCMS_BusinessLayer.Interface;
using MSCMS_BusinessLayer.Services;
using MSCMS_Datalayer.DTO;
using MSCMS_Datalayer.Entities;
using MSCMS_DataLayer;
using Microsoft.Extensions.Logging;

namespace MSCMS_Presentationlayer.Controllers
{
    /// <summary>
    /// Config Controller : created by Nixon, last updated : 18/07/2023
    /// Description : Conig Controller is used for applcation configuration
    /// </summary>
    /// 

    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]

    //MSCMS_BusinessLayer
    public class ConfigController : Controller
    {
        //private readonly IConfig _StaffUsers;
        private readonly IConfig _config;
        //private readonly ILogger _logger;
        private readonly ILogger<ConfigController> _logger;
        public ConfigController(IConfig config, ILogger<ConfigController> logger)
        {
            //_StaffUsers = StaffUsers;
            _config = config;
            _logger = logger;
        }

        //Get all application logs
        [HttpGet("/application-log/")]
        public IActionResult GetApplicationlog()
        {
            try
            {
                return Ok(_config.GetApplicationconfig());
               
            }
            catch
            {
                return BadRequest("OOPS, Something Went Wrong, Try Again!");
            }

        }

        // Get application log using Id
        [HttpGet("/application-log/Id")]
        public IActionResult applicationlogby_ID(int Id)
        {
            try
            {
                _config.GetApplicationlogbyID(Id);
                return Ok(_config);

            }
            catch
            {
                return BadRequest("OOPS! something went wrong, Try again");
            }
        }

        //Get System Config details
        [HttpGet("/system-configuration")]
        public IActionResult systemconfiguration()
        {
            try
            {
                _logger.LogInformation("Reading System Configuration");
                //_config.GetSystemConfiguration();
                return Ok(_config.GetSystemConfiguration());
                
            }
            catch
            {
                return BadRequest("OOPS! something went wrong, Try again");
            }
        }

        //Get application config details
        [HttpGet("/application-config")]
        public IActionResult applicationconfig()
        {
            try
            {
                _config.GetApplicationconfig();
                return Ok(_config);
            }
            catch
            {
                return BadRequest("OOPS! something went wrong, Try again");
            }
        }

        //get current user details
        [HttpGet("/get_current_user")]
        public IActionResult get_current_user(int Id)
        {
            try
            {

                _config.GetCurrentUser(Id); 
                return Ok(_config);
            }
            catch
            {
                return BadRequest("OOPS! something went wrong, Try again");
            }
        }

        //Change password with on providing old password and update new password
        [HttpPut("/changepassword")]
        public IActionResult ChangePasswordByID(string OldPassword, string NewPassword, int UserId)
        {
            try
            {
                _config.ChangePasswordByID(OldPassword, NewPassword, UserId);
                return Ok("Password changed successfully");
            }
            catch
            {
                return BadRequest("OOPS! something went wrong, Try again");
            }
        }

        //Change password with on providing old password and update new password
        [HttpPut("/resetpassword")]
        public IActionResult ResetPasswordByID(string Password, int UId)
        {
            try
            {
               _config.ResetPasswordByID(Password, UId);
                return Ok("Password saved successfully");
            }
            catch
            {
                return BadRequest("OOPS! something went wrong, Try again");
            }
        }

        //Get all groups from db
        [HttpGet("/group")]
        public async Task<ActionResult<IEnumerable<SystemLicence>>> GetGroups(
        Guid authorId)
        {
            var getGroupsFromRepo = await _config.GetGroups();
            return Ok((getGroupsFromRepo));
        }
    }
}

