using Loja_de_Instrumentos.Data;
using Loja_de_Instrumentos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Hubs
{
    public class ChatHub : Hub
    {
        Context _context;
        IHttpContextAccessor _httpContextAccessor;

        public ChatHub(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendMessage(Message m)
        {
            m.Datetime = DateTime.Now;
            _context.Message.Add(m);
            _context.SaveChanges();
            await Clients.All.SendAsync("ReceiveMessage", m);
        }

        public string GetConnectionId() => Context.ConnectionId;
    }
}

