using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueWebChat.Models
{
    public class AppUser : IdentityUser
    {
        public List<Message> Messages { get; set; }
    }
}
