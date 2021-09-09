using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueWebChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Datetime { get; set; }
        public string userId { get; set; }
        public AppUser appUser { get; set; }
    }
}
