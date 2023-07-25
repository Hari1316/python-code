using System.ComponentModel.DataAnnotations;

namespace MSCMS_Datalayer.DTO
{
    public class _StaffUsers
    {
        [Key]
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
    }
}
