using System;

public interface IInventory
{
    int Capacity { get; set; }

    IInventoryItem GetItem(long itemID);
    IInventoryItem[] GetAllItems();
    IInventoryItem[] GetAllItems(long itemID);
    IInventoryItem[] GetEquippedItems();
    int GetItemCount(long itmeID);

    void AddItem(object sender, IInventoryItem item);
    bool TryRemove(object sender, long itemID, int count = 1);
    bool TryGetItem(long ID, out IInventoryItem item);
    IInventorySlot[] GetAllSlots();
}