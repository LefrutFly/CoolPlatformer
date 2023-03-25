using System;

public class InventorySlot : IInventorySlot
{
    public bool IsEmpty => Item == null;
    public InventoryItem Item => item;
    public long ItemID => Item.ID;
    public int Count => IsEmpty ? 0 : Item.Count;

    private InventoryItem item;


    public void SetItem(InventoryItem item)
    {
        if (!IsEmpty) return;

        this.item = item;
    }

    public void RemoveItems()
    {
        if (IsEmpty) return;

        item.Count = 0;
        item = null;
    }
}