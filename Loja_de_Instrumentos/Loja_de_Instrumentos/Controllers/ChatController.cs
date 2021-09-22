using Loja_de_Instrumentos.Data;
using Loja_de_Instrumentos.Hubs;
using Loja_de_Instrumentos.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Controllers
{

    
    public class ChatController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly Context _context;

        public ChatController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            ViewBag.Messages = _context.Message.ToList();
            return View();
        }

        public async Task<IActionResult> SendMessage(string Text, [FromServices] IHubContext<ChatHub> chat)
        {
            var sender = await _userManager.GetUserAsync(User);
            Message message = new Message
            {
                Text = Text,
                UserName = User.Identity.Name,
                userId = sender.Id,
                Datetime = DateTime.Now
            };

            _context.Message.Add(message);
            _context.SaveChanges();

            await chat.Clients.All.SendAsync("ReceiveMessage", message);
            //return RedirectToAction(nameof(Index));

            return Ok();
        }
    }
}
