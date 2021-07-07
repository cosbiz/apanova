using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public string Bio { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}