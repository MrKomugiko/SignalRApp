using Microsoft.AspNetCore.SignalR;
using SignalRApp.Server.Data;

namespace SignalRApp.Server.Hubs;

public class NotificationHub : Hub
{
    // USEFULL REGEX
    // inspector websocket filter regex empty and ping
    // ^(?!.*("type":6)|{})
    //

    private readonly Storage _storage;
    public NotificationHub(Storage storage)
    {
        _storage = storage;
    }
    public async Task NotifyAllItemChanged(Guid id)
    {
        await Clients.All.SendAsync("itemChanged", id);
    }

    public async Task NotifyOthersItemWasOpened(Guid id)
    {
        _storage.ItemsCurrentlyInUse.Add(id);
        await Clients.Others.SendAsync("itemIsInUse", id);
    }

    public async Task NotifyOthersItemWasClosed(Guid id)
    {
        _storage.ItemsCurrentlyInUse.Remove(id);
        await Clients.Others.SendAsync("itemNoMoreInUse", id);
    }

    public Task<HashSet<Guid>> Connect()
    {
        return Task.FromResult(_storage.ItemsCurrentlyInUse);
    }
}