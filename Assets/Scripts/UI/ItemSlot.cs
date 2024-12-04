using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI countText;
    public Button useButton;

    private ItemType itemType;
    private int itemCount;

    public void Setup(ItemType type, int count)
    {
        itemType = type;
        itemCount = count;

        itemNameText.text = GetItemDisplayName(type);
        countText.text = count.ToString();

        useButton.onClick.AddListener(UseItem);
    }

    private string GetItemDisplayName(ItemType type)
    {
        switch(type)
        {
            case ItemType.VegetableStew: return "��ä ��Ʃ";
            case ItemType.FruiSalad: return "���� ������";
            case ItemType.RepairKit: return "���� ŰƮ";
            default: return type.ToString();
        }
    }

    private void UseItem()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
        SurvivalStats stats = FindObjectOfType<SurvivalStats>();

        switch (itemType)
        {
            case ItemType.VegetableStew:
                if (inventory.Removeitme(itemType, 1))
                {
                    stats.EatFood(40f);
                    InventoryUIManager.instance.RefreshInventory();
                }
                break;
            case ItemType.FruiSalad:
                if (inventory.Removeitme(itemType, 1))
                {
                    stats.EatFood(50f);
                    InventoryUIManager.instance.RefreshInventory();
                }
                break;
            case ItemType.RepairKit:
                if (inventory.Removeitme(itemType, 1))
                {
                    stats.RepairSuit(25f);
                    InventoryUIManager.instance.RefreshInventory();
                }
                break;
        }
    }
}
