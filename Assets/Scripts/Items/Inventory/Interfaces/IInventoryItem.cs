using UnityEngine;

public interface IInventoryItem
{
    bool IsEquipped { get; set; }
    long ID { get; }
    string Name { get; set; }
    int Count { get; set; }
    Sprite Sprite { get; set; }
}
