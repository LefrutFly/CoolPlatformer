using UnityEngine;

public class ItemBuilder : MonoBehaviour
{
    [SerializeField] private ItemSlotUI itemSlotUIPrefabe;
    [SerializeField] private Transform content;

    public IInventory Inventory => inventory;

    private IInventory inventory;


    private void Start()
    {
        var inventory = GameLinks.GetLink<Player>().inventory;
        Init(inventory);
        Build();

        (inventory as InventorySlotsData).InventoryUpdatedEvent += Build;
    }

    private void OnDestroy()
    {
        if (inventory != null)
            (inventory as InventorySlotsData).InventoryUpdatedEvent -= Build;
    }

    public void Init(IInventory inventory)
    {
        this.inventory = inventory;
    }

    private void Build()
    {
        var itemlist = inventory.GetAllItems();

        for (int i = 0; i < itemlist.Length; i++)
        {
            InventoryItem item = itemlist[i];
            var slot = Instantiate(itemSlotUIPrefabe, content);
            slot.Init(item);
        }
    }
}
