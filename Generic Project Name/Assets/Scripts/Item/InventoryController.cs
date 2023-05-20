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

        int x = 0; 
        int y = 0;

        float slotCellSize = 45.0f;

        foreach (Item item in inventory.GetItemList()) 
        {
            RectTransform slotRectTransform = Instantiate(slotTemplate, inventoryPanel).GetComponent<RectTransform>(); 
            
            slotRectTransform.gameObject.SetActive(true);




            slotRectTransform.GetComponent<ButtonUI>().onLeftClick.AddListener( () => {
                Transform itemInfo = slotRectTransform.Find("Info");
                if (itemInfo.gameObject.activeInHierarchy)
                {
                    itemInfo.gameObject.SetActive(false);
                }
                else
                {
                    // Make sure to disable other text before showing a new
                    foreach(GameObject info in GameObject.FindGameObjectsWithTag("ItemInfo"))
                    {
                        info.SetActive(false);
                    }


                    itemInfo.gameObject.SetActive(true);
                    TextMeshProUGUI infoDisplay = itemInfo.GetComponent<TextMeshProUGUI>();
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
            }
            );
            slotRectTransform.GetComponent<ButtonUI>().onRightClick.AddListener( () => {
                // use the item
                Debug.Log("Gonna use item");
                inventory.UseItem(item);
            }
            );










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
    }
}
