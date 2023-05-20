using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChange;
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void AddItem(Item item)
    {
        bool itemAlreadyInInventory = false;
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            {
                inventoryItem.amount += 1;
                itemAlreadyInInventory = true;
            }
        }
        if (!itemAlreadyInInventory)
        {
            itemList.Add(item);
        }

        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }
}
