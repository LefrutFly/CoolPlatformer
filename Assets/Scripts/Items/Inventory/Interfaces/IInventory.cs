using System;

public interface IInventory
{
    int Capacity { get; set; }

    InventoryItem GetItem(long itemID);
    InventoryItem[] GetAllItems();
    InventoryItem[] GetAllItems(long itemID);
    InventoryItem[] GetEquippedItems();
    int GetItemCount(long itmeID);

    void AddItem(object sender, InventoryItem item);
    bool TryRemove(object sender, long itemID, int count = 1);
    bool TryGetItem(long ID, out InventoryItem item);
    IInventorySlot[] GetAllSlots();
}