using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PassItem : MonoBehaviour, ICollectible
{
    public static event HandlePassCollected OnPasswordCollected;
    public delegate void HandlePassCollected(ItemData itemData);
    public ItemData passwordData;

    public void Collect()
    {
        Debug.Log("Item has been picked up");
        //Destroy(gameObject);
        OnPasswordCollected?.Invoke(passwordData);
    }
}
