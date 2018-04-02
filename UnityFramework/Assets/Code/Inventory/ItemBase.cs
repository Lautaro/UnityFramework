using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase  {

    public string Name { get; set; }

    int maxAmount = 100;
    public int MaxAmount
    {
        get
        {
            return maxAmount;
        }
    }

    int amount = 23;
    public int Amount
    {
        get
        {
            return Amount;
        }

        set
        {
            Amount = value;
        }
    }

    internal string spriteDirectoryPath = "InventoryIcons/";
    string spriteName;
    public string SpriteName
    {
        get
        {
            return spriteName;
        }

        set
        {
            spriteName = value;
        }
    }
    
    public string GetIconSpriteFilePath()
    {
        return spriteDirectoryPath + spriteName;
    }
}
