namespace MSCMS_Datalayer.Entities
{
    public class LoginResponse : BaseModel

    {
        public LoginResponse(string expires_in, string token_type, string Scope, DateTime accessTokenExpiry)
        {
            this.expires_in = expires_in;
            this.token_type = token_type;
            this.AccessTokenExpiry = accessTokenExpiry;            
        }

        public string? access_token { get; set; }
        public string? expires_in { get; set; }
        public string? token_type { get; set; }
        public string? Scope { get; set; }    
        public RefreshToken? refresh_token { get; set; }
        public DateTime AccessTokenExpiry { get; set; }

    }

}