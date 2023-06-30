using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRApp.Server.Data;
using SignalRApp.Server.Hubs;
using SignalRApp.Shared;
using System.Linq;

namespace SignalRApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly Storage _storage;
    private readonly NotificationHub _nHub;

    public ItemsController(Storage storage, NotificationHub nHub)
    {
        this._storage = storage;
        this._nHub = nHub;
    }

    //[HttpPatch]
    //public async Task<ActionResult<Item>> PatchItem([FromQuery] Guid id, [FromBody] JsonPatchDocument<Item> patchDoc)
    //{
    //    Item? itemQuery = _storage.AllItems.SingleOrDefault(x=>x.Id == id);
    //    if(itemQuery == null)
    //    {
    //        return NotFound();
    //    }
    //    patchDoc.ApplyTo(itemQuery);

    //    return Ok(itemQuery);
    //}

    [HttpPost]
    public async Task<ActionResult<Item>> UpdateItem([FromQuery] Guid id, [FromBody] Item updatedItem)
    {
        if (updatedItem is null) 
            return BadRequest("Item cannot be null");

        int index = _storage.AllItems.FindIndex(item => item.Id == updatedItem.Id);   

        if (index != -1)
        {
            updatedItem.Updated = DateTime.Now;
            _storage.AllItems[index] = updatedItem;
        }
        else
        {
            return NotFound($"Item with Id {id} was not found in databnase.");
        }
        await _nHub.NotifyAllItemChanged(id);
        return Ok(_storage.AllItems[index]);
    }

    [HttpGet("GetAll")] public List<Item> GetAll() => _storage.AllItems;

    [HttpGet("Get")] public Item? Get([FromQuery] Guid id) => _storage.AllItems.FirstOrDefault(x => x.Id == id);
}