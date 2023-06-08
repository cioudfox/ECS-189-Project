using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public Sprite blueGemSprite;
    public Sprite diaGemSprite;
    public Sprite greenGemSprite;
    public Sprite redGemSprite;
    public Sprite tearGemSprite;
    public Sprite yellowGemSprite;
    public Sprite mushroomSprite;
    public Sprite heartSprite;
    public Sprite critSprite;
    public Sprite swiftSprite;
}
