using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShifaaAPI.Models.Identity
{
    public class User : IdentityUser<int>
    {

        [MaxLength(50)]
        public required string Name { get; set; }
        public required string Password { get; set; }
        public byte[]? Photo { get; set; }
        public int RoleId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
