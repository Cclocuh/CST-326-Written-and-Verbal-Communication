using Microsoft.AspNetCore.Identity;
using System;

namespace OnlineGroceryStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}

