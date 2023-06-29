using SignalRApp.Server.Data;

namespace SignalRApp.Tests;

public class StorageServiceTests
{
    [Fact]
    public void Storage_Initialize_ShouldCountainsPopulatedItemsList()
    {
        Storage _storage = new();
        Assert.NotEmpty(_storage.AllItems);
    }

    [Fact]
    public void AllItems_AllItemsHasUniqueGuidId_ShouldBeTrue()
    {
        Storage _storage = new();
        Assert.True(_storage.AllItems.DistinctBy(x=>x.Id).Count() == _storage.AllItems.Count);
    }
}