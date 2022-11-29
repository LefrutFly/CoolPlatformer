using System;

public interface IInventorySlot
{
    bool IsEmpty { get; }

    IInventoryItem Item { get; }
    long ItemID { get; }
    int Count { get; }

    void SetItem(IInventoryItem item);
    void RemoveItems();
}
