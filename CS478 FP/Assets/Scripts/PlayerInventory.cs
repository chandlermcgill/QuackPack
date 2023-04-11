using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static event Action<List<InventItem>> OnInventoryChange;

    public List<InventItem> inventory = new List<InventItem>();
    private Dictionary<ItemData, InventItem> itemDictionary = new Dictionary<ItemData, InventItem>();

    public void Add(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventItem item))
        {
            item.AddToStack();
            Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventItem newItem = new InventItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added {itemData.displayName} to the inventory for the first time");
            OnInventoryChange?.Invoke(inventory);
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
            OnInventoryChange?.Invoke(inventory);
        }
    }

    private void OnEnable()
    {
        PassItem.OnPasswordCollected += Add;
    }
    private void OnDisable()
    {
        PassItem.OnPasswordCollected -= Add;
    }
}
