using SignalRApp.Shared;

namespace SignalRApp.Server.Data;

public class Storage
{
    public List<Item> AllItems = new();
    public HashSet<Guid> ItemsCurrentlyInUse { get; set; } = new();
    public Storage()
    {
        // Seed data
        AllItems = new()
        {
            new Item {
                Id = Guid.NewGuid(),
                created = DateTime.Now,
                updated = DateTime.Now,
                name = "Item 1",
                value = "1"
            },
            new Item {
                Id = Guid.NewGuid(),
                created = DateTime.Now,
                updated = DateTime.Now,
                name = "Item 2",
                value = "2"
            },
            new Item {
                Id = Guid.NewGuid(),
                created = DateTime.Now,
                updated = DateTime.Now,
                name = "Item 3",
                value = "3"
            }
        };
    }
}
