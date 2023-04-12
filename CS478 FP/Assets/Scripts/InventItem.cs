using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventItem
{
    public ItemData itemData;
    public int stackSize;
    public bool isStackable;

    public InventItem(ItemData item)
    {
        itemData = item;
        AddToStack();
    }

    public void AddToStack()
    {
        if (itemData.isStackable == true)
        {
            stackSize++;
        }
        else
        {
            stackSize = 1;
        }
        
    }
    public void RemoveFromStack()
    {
        stackSize--;
    }
}
