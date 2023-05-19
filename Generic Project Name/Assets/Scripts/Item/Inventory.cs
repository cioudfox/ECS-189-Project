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
        itemList.Add(item);
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }
}
