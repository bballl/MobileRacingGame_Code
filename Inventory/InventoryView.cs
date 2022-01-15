using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : IInventoryView
{
    public event Action<IItem> Selected;
    public event Action<IItem> Deselected;

    public void Display(IReadOnlyList<IItem> items)
    {
        foreach(var item in items)
            Debug.Log($"Id item: {item.Id}. Title item: {item.Info.Title}");
    }

    public void Hide()
    {
        Debug.Log($"Close Inventory");
    }

    protected virtual void OnSelected(IItem item)
    {
        Selected?.Invoke(item);
    }

    protected virtual void OnDeselected(IItem item)
    {
        Deselected?.Invoke(item);
    }
}
