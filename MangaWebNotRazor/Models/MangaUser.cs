using Microsoft.AspNetCore.Identity;

namespace MangaWebNotRazor.Models
{
    public class MangaUser : IdentityUser
    {
        public override string? Id { get; set; }   
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set;}
        public string? Password { get; set; }
        public bool? IsEmailConfirmed { get; set;}
    }
}
