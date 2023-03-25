using System;

public interface IInventorySlot
{
    bool IsEmpty { get; }

    InventoryItem Item { get; }
    long ItemID { get; }
    int Count { get; }

    void SetItem(InventoryItem item);
    void RemoveItems();
}
