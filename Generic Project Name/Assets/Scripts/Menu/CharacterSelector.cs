using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public CharacterScriptableObject chraterData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);   
        }
        else
        {
            Debug.LogWarning("Extra" + this + " Deleted");
            Destroy(gameObject);
        }
    }

    public static CharacterScriptableObject getData()
    {
        return instance.chraterData;
    }

    public void SelectCharacter(CharacterScriptableObject character)
    {
        chraterData = character;
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
