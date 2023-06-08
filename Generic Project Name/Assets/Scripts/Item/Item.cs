using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType 
    {
        BlueGem,
        DiaGem,
        GreenGem,
        RedGem,
        TearGem,
        YellowGem,
        Mushroom,
        Heart,
        CriticalSurge,
        Swift
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            case ItemType.BlueGem:
                return ItemAssets.Instance.blueGemSprite;
            case ItemType.DiaGem:
                return ItemAssets.Instance.diaGemSprite;
            case ItemType.GreenGem:
                return ItemAssets.Instance.greenGemSprite;
            case ItemType.RedGem:
                return ItemAssets.Instance.redGemSprite;
            case ItemType.TearGem:
                return ItemAssets.Instance.tearGemSprite;
            case ItemType.YellowGem:
                return ItemAssets.Instance.yellowGemSprite;
            case ItemType.Mushroom:
                return ItemAssets.Instance.mushroomSprite;
            case ItemType.Heart:
                return ItemAssets.Instance.heartSprite;
            case ItemType.CriticalSurge:
                return ItemAssets.Instance.critSprite;
            case ItemType.Swift:
                return ItemAssets.Instance.swiftSprite;
            default:
                Debug.Log("Invalid Item Type.");
                return null;
        }
    }
}
