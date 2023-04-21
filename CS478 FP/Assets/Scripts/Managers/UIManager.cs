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

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
