using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public static event Action<List<InventItem>> OnInventoryChange;
    //public static PlayerInventory instance;

    public List<InventItem> inventory = new List<InventItem>();
    private Dictionary<ItemData, InventItem> itemDictionary = new Dictionary<ItemData, InventItem>();

    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}

        if (SceneManager.GetSceneByName("InventUI").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("InventUI", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync("InventUI");
        }

    }

    public void Add(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventItem item))
        {
            if (itemData.isStackable == true)
            {
                item.AddToStack();
                Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
                OnInventoryChange?.Invoke(inventory);
            }
           
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
