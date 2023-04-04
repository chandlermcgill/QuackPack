//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "Item", menuName = "CS478 FP/Inventory")]
//public class PlayerInventory : ScriptableObject
//{
//    [SerializeField] List<Item> items;
//    [SerializeField] Transform itemsParent;
//    [SerializeField] ItemSlot[] itemSlots;

//    private void OnValidate()
//    {
//        if (itemsParent != null)
//        {
//            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
//        }
//    }
//}
