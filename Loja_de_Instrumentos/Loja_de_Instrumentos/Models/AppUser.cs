using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Loja_de_Instrumentos.Models
{
    public class AppUser: IdentityUser
    {
        public List<Message> Messages { get; set; }
    }
}
