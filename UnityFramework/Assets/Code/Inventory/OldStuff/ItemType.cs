using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A type of item that can be stored and used by players
/// </summary>
public class ItemType : ScriptableObject {

    public int maxItemAmount;
    public string ItemName;
    public int amount;
    public Sprite Sprite;

    public void DoTransaction(ItemStack incomingItemStash)
    {
        if (incomingItemStash == null
            || incomingItemStash.Amount < 1
            || incomingItemStash.ItemType.name != name)
        {
            return;
        }

        // INCOMING STASH IS SAME TYPE 
        if (incomingItemStash.ItemType.name == name)
        {
            var max = maxItemAmount;
            var tryToAddAmount = incomingItemStash.Amount;

            // IF TOTAL AMOUNT IS TO MUCH -> RETURN EXCESS
            if (amount + tryToAddAmount > maxItemAmount)
            {
                amount += incomingItemStash.Take(max - amount);
                return;
            }
        }
    }

    public int Take(int takeAmount)
    {
        if (amount - takeAmount < 0)
        {
            int returnAmount = amount;
            amount = 0;
            return returnAmount;
        }
        else
        {
            amount -= takeAmount;
            return takeAmount;
        }
    }
}
