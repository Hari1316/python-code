using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSCMS_BackEnd.Data;
using MSCMS_BusinessLayer.Interface;
using MSCMS_Datalayer.DTO;
using MSCMS_Datalayer.Entities;
using MSCMS_DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MSCMS_BusinessLayer.Services
{
    public class config : IConfig
    {
        private readonly MSCMSDbContext _db;
        private readonly cls_helper _helper;
        private readonly cls_hasing _hash;
        StaffUser staff = new StaffUser();
        _UserGroups ugroup = new _UserGroups();
        
        public config(MSCMSDbContext db, cls_helper helper, cls_hasing hash)
        {
           
            _db = db;
            _helper = helper;
            _hash = hash;
        }

        public List<string> GetApplicationlogs()
        {
            var list = _db.StaffApplicationlogs.ToList();

            return new List<string>();
        }

        public List<string> GetApplicationlogbyID(int Id)
        {
            
                var List = _db.StaffUsers.Where(
                                   p => p.Id == Id)
                                   .Select(s => s.Id).FirstOrDefault();


                return new List<string>();
            
        }

        public List<SystemSystemconfiguration> GetSystemConfiguration()
        {
            var List = from ed in _db.SystemSystemconfigurations
                      select new
                      {
                          Id = ed.Id,
                          email_server_address = ed.EmailServerAddress,
                          email_username = ed.EmailUsername,
                          email_password = ed.EmailPassword,
                          email_notifications_enabled = ed.EmailNotificationsEnabled,
                          created_timestamp = ed.CreatedTimestamp,
                          last_modified_timestamp = ed.LastModifiedTimestamp,
                          email_server_port = ed.EmailServerPort
                      };

            return new List<SystemSystemconfiguration>();
        }

        public List<string> GetApplicationconfig()
        {

            var val = from ed in _db.StaffApplicationconfigs
                      select new

                      {
                          Id = ed.Id,
                          key = ed.Key,
                          value = ed.Value,
                          created_timestamp = ed.CreatedTimestamp,
                          last_modified_timestamp = ed.LastModifiedTimestamp,
                          user = ed.User,
                          last_modified_user = ed.LastModifiedUser

                      };
            return new List<string>();
        }

        public List<string> GetCurrentUser(int Id)
        {
            var List = from user in _db.StaffUsers
                       where user.Id == Id
                       select new
                       {
                           Id = user.Id,
                           Username = user.Username,
                           Password = user.Password,
                           LastLogin = user.LastLogin,
                           IsSuperuser = user.IsSuperuser
                       };
            return new List<string>();

        }
        public void ChangePasswordByID(string OldPassword, string NewPassword, int UId)
        {
            try
            {

                var encryptedtext = _db.StaffUsers.Where(
                                   p => p.Id == UId)
                                   .Select(s => s.Password).FirstOrDefault();

                string result = _hash.Decrypt(OldPassword, encryptedtext);

                if (result != null)
                {
                    string val = _hash.Encrypt(NewPassword);

                    var username = _db.StaffUsers.Where(
                                 p => p.Id == UId)
                                 .Select(s => s.Username).FirstOrDefault();

                    var first_name = _db.StaffUsers.Where(
                                 p => p.Id == UId)
                                 .Select(s => s.FirstName).FirstOrDefault();

                    var last_name = _db.StaffUsers.Where(
                                 p => p.Id == UId)
                                 .Select(s => s.LastName).FirstOrDefault();

                    var invalid_login_attempts = _db.StaffUsers.Where(
                                 p => p.Id == UId)
                                 .Select(s => s.InvalidLoginAttempts).FirstOrDefault();

                    var is_locked_out = _db.StaffUsers.Where(
                                 p => p.Id == UId)
                                 .Select(s => s.IsLockedOut).FirstOrDefault();
                    var notify = _db.StaffUsers.Where(
                                 p => p.Id == UId)
                                 .Select(s => s.Notify).FirstOrDefault();

                    staff.Id = UId;
                    staff.Username = username;
                    staff.FirstName = first_name;
                    staff.LastName = last_name;
                    staff.Password = val;
                    staff.Email = "Not Needed";
                    staff.InvalidLoginAttempts = invalid_login_attempts;
                    staff.IsLockedOut = is_locked_out;
                    staff.Notify = notify;
                    _db.StaffUsers.Update(staff);
                    _db.SaveChanges();
                   
                }             
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public void ResetPasswordByID(string Password, int UId)
        {
            try { 
                string val = _hash.Encrypt(Password);

                var username = _db.StaffUsers.Where(
                             p => p.Id == UId)
                             .Select(s => s.Username).FirstOrDefault();

                var first_name = _db.StaffUsers.Where(
                             p => p.Id == UId)
                             .Select(s => s.FirstName).FirstOrDefault();

                var last_name = _db.StaffUsers.Where(
                             p => p.Id == UId)
                             .Select(s => s.LastName).FirstOrDefault();

                var invalid_login_attempts = _db.StaffUsers.Where(
                             p => p.Id == UId)
                             .Select(s => s.InvalidLoginAttempts).FirstOrDefault();

                var is_locked_out = _db.StaffUsers.Where(
                             p => p.Id == UId)
                             .Select(s => s.IsLockedOut).FirstOrDefault();
                var notify = _db.StaffUsers.Where(
                             p => p.Id == UId)
                             .Select(s => s.Notify).FirstOrDefault();

                staff.Id = UId;
                staff.Username = username;
                staff.FirstName = first_name;
                staff.LastName = last_name;
                staff.Password = val;
                staff.Email = "Not Needed";
                staff.InvalidLoginAttempts = invalid_login_attempts;
                staff.IsLockedOut = is_locked_out;
                staff.Notify = notify;
                _db.StaffUsers.Update(staff);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public async Task<ActionResult<IEnumerable<_UserGroups>>>GetGroups()
        {
            var GroupFromRepo = await _db.AuthGroups.ToArrayAsync();

            return new List (GroupFromRepo);
        }
    }


}
