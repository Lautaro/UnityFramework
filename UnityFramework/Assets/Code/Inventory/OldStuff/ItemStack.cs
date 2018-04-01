using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Many of the same item
/// </summary>
[Serializable]
public class ItemStack
{

    public ItemType ItemType;
[SerializeField]
    private int amount;
    public int Amount
    {
        get
        {
            return amount;
        }
    }


    public void DoTransaction(ItemStack incomingItemStash)
    {
        if (incomingItemStash == null
            || incomingItemStash.Amount < 1
            || incomingItemStash.ItemType.name != ItemType.name)
        {
            return;
        }

        // INCOMING STASH IS SAME TYPE 
        if (incomingItemStash.ItemType.name == ItemType.name)
        {

            var max = ItemType.maxItemAmount;
            var tryToAddAmount = incomingItemStash.Amount;

            // IF TOTAL AMOUNT IS TO MUCH -> RETURN EXCESS
            if (Amount + tryToAddAmount > ItemType.maxItemAmount)
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
