using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A container where a stack of items is kept
/// </summary>
public class ItemContainer : MonoBehaviour {

   [SerializeField]
    public ItemType Stack;
    
   /* public void MergeSlots(ItemContainer mergeStack)
    {
        if (mergeStack.Stack.name == mergeStack.Stack.name)
        {
            Stack.DoTransaction(mergeStack.Stack);
        }
        else
        {
            var tempStash = Stack;
            Stack = mergeStack.Stack;
            mergeStack.Stack = tempStash;
        }
    } */
}
