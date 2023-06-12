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
    private PlayerController playerController;

    void Awake()
    {
        inventoryPanel = transform.Find("InventoryPanel");
        slotTemplate = inventoryPanel.Find("SlotTemplate");
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
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

        float consumableRowX = 0.0f; 
        float consumableRowY = 0.0f;

        float treaRowX = 0.0f;
        float treaRowY = 1.4f;
        float slotCellSize = 100.0f;

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
                    case Item.ItemType.BlueGem:
                        infoDisplay.SetText("It is a Blue gem.");
                        break;
                    case Item.ItemType.DiaGem:
                        infoDisplay.SetText("It is a Dia gem.");
                        break;
                    case Item.ItemType.GreenGem:
                        infoDisplay.SetText("It is a Green gem.");
                        break;
                    case Item.ItemType.RedGem:
                        infoDisplay.SetText("It is a Red gem.");
                        break;
                    case Item.ItemType.TearGem:
                        infoDisplay.SetText("It is a Tear gem.");
                        break;
                    case Item.ItemType.YellowGem:
                        infoDisplay.SetText("It is a Yellow gem.");
                        break;
                    case Item.ItemType.Mushroom:
                        infoDisplay.SetText("It is a mushroom.");
                        break;
                    case Item.ItemType.Heart:
                        infoDisplay.SetText("Heart: Restore health.");
                        break;
                    case Item.ItemType.CriticalSurge:
                        infoDisplay.SetText("CriticalSurge: Increase critical hit chance and attack speed.");
                        break;
                    case Item.ItemType.Swift:
                        infoDisplay.SetText("Swift: Increase movement speed.");
                        break;
                }
            }
            );

            slotRectTransform.GetComponent<ButtonUI>().onMouseExit.AddListener( () => {
                // Transform itemInfo = slotRectTransform.Find("Info");
                Transform inventoryRoot = slotRectTransform.parent.parent;
                Transform description = inventoryRoot.Find("ItemInfo");

                description.gameObject.SetActive(false);

            }
            );

            slotRectTransform.GetComponent<ButtonUI>().onRightClick.AddListener( () => {
                // use the item
                if (item.itemType == Item.ItemType.Heart || item.itemType == Item.ItemType.CriticalSurge || item.itemType == Item.ItemType.Swift)
                {
                    inventory.UseItem(item);
                }
            }
            );







            if (item.itemType == Item.ItemType.Heart || item.itemType == Item.ItemType.CriticalSurge || item.itemType == Item.ItemType.Swift)
            {
                if (item.itemType == Item.ItemType.Heart)
                {
                    consumableRowX = 0.0f;
                }
                else if (item.itemType == Item.ItemType.CriticalSurge)
                {
                    consumableRowX = 1.0f;
                }
                else if (item.itemType == Item.ItemType.Swift)
                {
                    consumableRowX = 2.0f;
                }
                slotRectTransform.anchoredPosition = new Vector2(consumableRowX * slotCellSize, -consumableRowY * slotCellSize);

                Image image = slotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = item.GetSprite();

                TextMeshProUGUI uiText = slotRectTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                
                uiText.SetText(item.amount.ToString());

                // Cooldown visuals
                GameObject inventoryGameObject = GameObject.FindGameObjectWithTag("Inventory");
                Image cooldownClockImage = slotRectTransform.Find("Cooldown").GetComponent<Image>();
                if (playerController.GetItemCooldownTimer() > 0.0f && cooldownClockImage && inventoryGameObject != null && inventoryGameObject.activeSelf)
                {
                    StartCoroutine(FillCooldownOverTime(cooldownClockImage));
                }
            }
            else
            {
                slotRectTransform.anchoredPosition = new Vector2(treaRowX * slotCellSize, -treaRowY * slotCellSize);

                Image image = slotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = item.GetSprite();

                TextMeshProUGUI uiText = slotRectTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                
                uiText.SetText(item.amount.ToString());

                treaRowX++;
                if (treaRowX >= 3) 
                { 
                    treaRowX = 0;
                    treaRowY++;
                }
            }
        }
    }

    private System.Collections.IEnumerator FillCooldownOverTime(Image image)
    {

        while (playerController.GetItemCooldownTimer() > 0.0f && image)
        {
            float fillAmount = playerController.GetItemCooldownTimer() / playerController.GetItemUsageCooldown();

            // Clamp the fill amount to ensure it stays between 0 and 1
            // fillAmount = Mathf.Clamp01(fillAmount);

            // Update the image fill amount
            image.fillAmount = fillAmount;

            yield return null;
        }

        if (image)
        {
            // Set the fill amount to 0 when the cooldown ends
            image.fillAmount = 0f; 
        }
    }
}