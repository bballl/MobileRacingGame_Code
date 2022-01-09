using System.Collections.Generic;

public class ItemsRepository : BaseController, IItemsRepository
{
    public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;

    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

    public ItemsRepository(List<ItemConfig> itemConfigs)
    {
        PopulateItems(itemConfigs);
    }

    protected override void OnDispose()
    {
        _itemsMapById.Clear();
    }

    private void PopulateItems(List<ItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_itemsMapById.ContainsKey(config.Id))
                continue;

            _itemsMapById.Add(config.Id, CreateItem(config));
        }
    }

    private IItem CreateItem(ItemConfig config)
    {
        var itemInfo = new ItemInfo { Title = config.Title };

        return new Item
        {
            Id = config.Id,
            Info = itemInfo
        };
    }
}
