using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text countText;

    private InventoryItem item;

    public InventoryItem Item => item;

    public void Init(InventoryItem item)
    {
        this.item = item;
        item.UpdatedEvent += UpdateUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        if (item != null)
            item.UpdatedEvent -= UpdateUI;
    }

    private void UpdateUI()
    {
        icon.sprite = item.Sprite;
        nameText.text = item.Name;
        countText.text = "x" + item.Count;
    }
}
