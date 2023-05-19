using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private Inventory inventory;
    private Transform inventoryPanel;
    private Transform slotTemplate;

    void Awake()
    {
        inventoryPanel = transform.Find("InventoryPanel");
        slotTemplate = inventoryPanel.Find("SlotTemplate");

    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() 
    {
        int x = 0; 
        int y = 0;

        float slotCellSize = 25.0f;

        foreach (Item item in inventory.GetItemList()) 
        {
            RectTransform slotRectTransform = Instantiate(slotTemplate, inventoryPanel).GetComponent<RectTransform>(); 
            
            slotRectTransform.gameObject.SetActive(true);

            slotRectTransform.anchoredPosition = new Vector2(x * slotCellSize, y * slotCellSize);
            
            Image image = slotRectTransform.GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if (x > 4) 
            { 
                x = 0;
                y++;
            }
        }
    }
}
