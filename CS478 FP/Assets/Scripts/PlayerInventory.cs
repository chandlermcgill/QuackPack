using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventItem> inventory = new List<InventItem>();
    private Dictionary<ItemData, InventItem> itemDictionary = new Dictionary<ItemData, InventItem>();

    public void Add(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventItem item))
        {
            item.AddToStack();
        }
        else
        {
            InventItem newItem = new InventItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
        }
    }

    public void Remove(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
