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
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Name = "Item 1",
                Value = "1"
            },
            new Item {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Name = "Item 2",
                Value = "2"
            },
            new Item {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Name = "Item 3",
                Value = "3"
            }
        };
    }
}
