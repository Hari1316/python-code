using Microsoft.AspNetCore.Mvc;
using MSCMS_BackEnd.Data;
using MSCMS_Datalayer.DTO;
using MSCMS_Datalayer.Entities;
using MSCMS_DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMS_BusinessLayer.Interface
{
    public interface IConfig
    {
        List<string> GetApplicationlogs();

        List<string> GetApplicationlogbyID(int Id);

        List<SystemSystemconfiguration> GetSystemConfiguration();

        List<string> GetApplicationconfig();

        List<string> GetCurrentUser(int Id);

        public void ChangePasswordByID(string OldPassword, string NewPassword, int UId);

        public void ResetPasswordByID(string Password, int UId);

        Task<ActionResult<IEnumerable<_UserGroups>>> GetGroups();
    }
}
