namespace MSCMS_Datalayer.Entities
{
    public class LoginRequest
    {
        public LoginRequest()
        {
            this.UserName = String.Empty;
            this.Password = String.Empty;
            
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        //public string client_id { get; set; }
        //public string client_secret { get; set; } 
        //public string grant_type { get; set; } 

    }
}
