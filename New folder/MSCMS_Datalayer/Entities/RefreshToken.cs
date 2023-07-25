using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MSCMS_Datalayer.Entities
{
    public class RefreshToken : BaseModel
    {
        public RefreshToken(string token, string tokenType, DateTime expiration, string username)
        {
            Token = token;
            TokenType = tokenType;
            Expiration = expiration;
            Username = username;
        }

        public string Token { get; set; }
        public string TokenType { get; set; }
        public DateTime Expiration { get; set; }
        public string Username { get; set; }
    }
}
