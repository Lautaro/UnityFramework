using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A container where a stack of items is kept
/// </summary>
public class ItemContainer : MonoBehaviour
{

    [SerializeField]
    private ItemBase stack;

    public ItemBase Stack
    {
        get
        {
            return stack;
        }

        set
        {
            print("New stack set");
            stack = value;
        }
    }


    private void Update()
    {
 
    }

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
