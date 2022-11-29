using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotsData : IInventory
{
    public event Action<object, IInventoryItem, int> InventoryItemsAddedEvent;
    public event Action<object, long, int> InventoryItemsRemovedEvent;

    public int Capacity { get; set; }

    private List<InventorySlot> slots;


    public InventorySlotsData(int maxSize)
    {
        slots = new List<InventorySlot>(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            slots.Add(new InventorySlot());
        }
    }


    public IInventoryItem GetItem(long itemID)
    {
        return slots.Find(slot => slot.ItemID == itemID).Item;
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();

        foreach (var slot in slots)
        {
            if (!slot.IsEmpty)
            {
                allItems.Add(slot.Item);
            }
        }

        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(long itemID)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotsOfType = slots.FindAll(slot => !slot.IsEmpty && slot.ItemID == itemID);

        foreach (var slot in slotsOfType)
        {
            if (!slot.IsEmpty)
            {
                allItemsOfType.Add(slot.Item);
            }
        }

        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var equippedItems = new List<IInventoryItem>();
        var requiredSlots = slots.FindAll(slot => !slot.IsEmpty && slot.Item.IsEquipped);

        foreach (var slot in requiredSlots)
        {
            if (!slot.IsEmpty)
            {
                equippedItems.Add(slot.Item);
            }
        }

        return equippedItems.ToArray();
    }

    public int GetItemCount(long itemID)
    {
        var count = 0;
        var allItemsSlots = slots.FindAll(slot => !slot.IsEmpty && slot.ItemID == itemID);

        foreach (var item in allItemsSlots)
        {
            count += item.Count;
        }

        return count;
    }

    public void AddItem(object sender, IInventoryItem item)
    {
        var slotWithSameItemsButNotEmpty = slots.Find(slot => !slot.IsEmpty && slot.ItemID == item.ID);
        if (slotWithSameItemsButNotEmpty != null)
        {
            slotWithSameItemsButNotEmpty.Item.Count += item.Count;
        }

        var emptySlot = slots.Find(slot => slot.IsEmpty);
        emptySlot.SetItem(item);

        InventoryItemsAddedEvent?.Invoke(sender, item, item.Count);
    }

    public bool TryRemove(object sender, long itemID, int count = 1)
    {
        var slotWithItem = slots.Find(slot => !slot.IsEmpty && slot.ItemID == itemID);
        if (slotWithItem == null) return false;

        if (slotWithItem.Count - count > 0)
        {
            slotWithItem.Item.Count -= count;
            InventoryItemsRemovedEvent?.Invoke(sender, itemID, count);
            return true;
        }
        else if(slotWithItem.Count - count == 0)
        {
            slotWithItem.RemoveItems();
            InventoryItemsRemovedEvent?.Invoke(sender, itemID, count);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryGetItem(long itemID, out IInventoryItem item)
    {
        item = GetItem(itemID);
        return item != null;
    }

    public IInventorySlot[] GetAllSlots()
    {
        return slots.ToArray();
    }
}