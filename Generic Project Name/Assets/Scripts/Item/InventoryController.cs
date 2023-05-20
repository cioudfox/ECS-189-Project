using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        inventory.OnItemListChange += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() 
    {
        foreach (Transform child in inventoryPanel)
        {
            if (child == slotTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        float x = 0.0f; 
        float y = 0.5f;

        float x2 = 0.0f;
        float y2 = 2.5f;
        float slotCellSize = 45.0f;

        foreach (Item item in inventory.GetItemList()) 
        {
            RectTransform slotRectTransform = Instantiate(slotTemplate, inventoryPanel).GetComponent<RectTransform>(); 
            
            slotRectTransform.gameObject.SetActive(true);




            slotRectTransform.GetComponent<ButtonUI>().onMouseEnter.AddListener( () => {
                Transform inventoryRoot = slotRectTransform.parent.parent;
                Transform description = inventoryRoot.Find("ItemInfo");

                description.gameObject.SetActive(true);
                TextMeshProUGUI infoDisplay = description.GetComponent<TextMeshProUGUI>();
                switch (item.itemType)
                {
                    case Item.ItemType.Gem:
                        infoDisplay.SetText("It is a gem.");
                        break;
                    case Item.ItemType.Mushroom:
                        infoDisplay.SetText("It is a mushroom.");
                        break;
                }
            }
            );

            slotRectTransform.GetComponent<ButtonUI>().onMouseExit.AddListener( () => {
                // Transform itemInfo = slotRectTransform.Find("Info");
                Transform inventoryRoot = slotRectTransform.parent.parent;
                Transform description = inventoryRoot.Find("ItemInfo");
                Debug.Log(description);

                description.gameObject.SetActive(false);

            }
            );

            slotRectTransform.GetComponent<ButtonUI>().onRightClick.AddListener( () => {
                // use the item
                Debug.Log("Gonna use item");
                inventory.UseItem(item);
            }
            );









            if (item.itemType == Item.ItemType.Gem)
            {
                slotRectTransform.anchoredPosition = new Vector2(x * slotCellSize, -y * slotCellSize);

                Image image = slotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = item.GetSprite();

                TextMeshProUGUI uiText = slotRectTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                
                uiText.SetText(item.amount.ToString());

                x++;
                if (x >= 4) 
                { 
                    x = 0;
                    y++;
                }
            }
            else if (item.itemType == Item.ItemType.Mushroom)
            {
                slotRectTransform.anchoredPosition = new Vector2(x2 * slotCellSize, -y2 * slotCellSize);

                Image image = slotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = item.GetSprite();

                TextMeshProUGUI uiText = slotRectTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                
                uiText.SetText(item.amount.ToString());

                x2++;
                if (x2 >= 4) 
                { 
                    x2 = 0;
                    y2++;
                }
            }
        }
    }
}