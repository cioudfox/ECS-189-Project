using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType 
    {
        Gem,
        Mushroom
    }

    public ItemType itemType;
    // public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            case ItemType.Gem:
                return ItemAssets.Instance.gemSprite;
            case ItemType.Mushroom:
                return ItemAssets.Instance.mushroomSprite;
            default:
                Debug.Log("Invalid Item Type.");
                return null;
        }
    }
}
