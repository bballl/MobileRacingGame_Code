using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IInventoryView _inventoryView;
    private readonly IItemsRepository _itemsRepository;

    
    public InventoryController(List<ItemConfig> itemConfigs)
    {
        _inventoryModel = new InventoryModel();
        _inventoryView = new InventoryView();
        _itemsRepository = new ItemsRepository(itemConfigs);
    }

    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventoryModel.EquipItem(item);

        var equippedItem = _inventoryModel.GetEquippedItems();
        _inventoryView.Display(equippedItem);
    }
}
