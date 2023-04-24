using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEditor;

[CreateAssetMenu(fileName = "UIManager", menuName = "ScriptableObjects/Managers/UIManager", order = 1)]
public class UIManager : ScriptableObject
{
    //public GameObject healthDroppedText;
    private Canvas sceneCanvas;
    //public GameState GameState { get; set; }

    private void OnEnable()
    {
        //PlayerEvents.onSpawnInvent += 
        
    }

    private void OnPlayerMove(List<InventItem> inventory, GameObject Inventory)
    {
        if (sceneCanvas == null)
        {
            sceneCanvas = GameObject.FindObjectOfType<Canvas>();
        }
    }

    private void OnDisable()
    {
        
    }
}
