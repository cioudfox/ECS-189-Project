using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item {itemType = Item.ItemType.Gem});
        AddItem(new Item {itemType = Item.ItemType.Mushroom});
        Debug.Log(itemList.Count);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
