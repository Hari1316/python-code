using Microsoft.AspNetCore.Mvc;
using MSCMS_BackEnd.Data;
using MSCMS_Datalayer.Entities;

namespace MSCMS_DataLayer.Helpers
{
    /// <summary>
    /// helper files Created by Nixon on 18/07/2023
    /// Description: general helper operation
    /// </summary>

    public class cls_helper 
    {
        private readonly MSCMSDbContext _db;
        StaffApplicationlog applog = new StaffApplicationlog();

        public cls_helper(MSCMSDbContext db)
        {
            _db = db;
        }

        public  IActionResult Savelog(int response, string method, string path, DateTime time, string ip, string body, string Query_params, int uid)
        {
            try
            {
                int i = 0;
                applog.Response = response;
                applog.Method = method;
                applog.Path = path;
                applog.Time = time; 
                applog.Ip = ip;
                applog.Body = body;
                applog.QueryParams = Query_params;
                applog.UserId = uid;


                _db.StaffApplicationlogs.Add(applog);
                i = _db.SaveChanges();

                return (IActionResult)applog;
            }
            catch (Exception ex) 
            {
                return (IActionResult)ex;

            }

        }
    }
}
