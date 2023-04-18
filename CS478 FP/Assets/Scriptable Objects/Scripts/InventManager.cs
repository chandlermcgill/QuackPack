using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<ItemSlot> inventSlots = new List<ItemSlot>(18);

    private void OnEnable()
    {
        PlayerInventory.OnInventoryChange += DrawInventory;
    }

    private void OnDisable()
    {
        PlayerInventory.OnInventoryChange -= DrawInventory;
    }

    void ResetInventory()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventSlots = new List<ItemSlot>(18);
    }

    void DrawInventory(List<InventItem> inventory)
    {
        ResetInventory();

        for (int i = 0; i < inventSlots.Capacity; i++)
        {
            //Create the inventory slots (18)
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            inventSlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);
        ItemSlot newSlotComponent = newSlot.GetComponent<ItemSlot>();
        newSlotComponent.ClearSlot();

        inventSlots.Add(newSlotComponent);
    }
}
