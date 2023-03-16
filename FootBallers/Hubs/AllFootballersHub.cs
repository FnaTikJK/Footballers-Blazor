using FootBallers.Entities;
using FootBallers.Models;
using Microsoft.AspNetCore.SignalR;

namespace FootBallers.Hubs
{
    public class AllFootballersHub : Hub
    {
        public Task UpdateList(List<FootballerDto> list)
        {
            return Clients.All.SendAsync("UpdateList", list);
        }
    }
}
