using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEditor;

[CreateAssetMenu(fileName = "RoomManager", menuName = "ScriptableObjects/Managers/RoomManager", order = 1)]
public class RoomManager : ScriptableObject
{
    public GameState GameState { get; set; }
    private void OnEnable()
    {
        RoomEvents.roomExit += OnRoomExit;
    }

    //Set player spawn location in the game state for the next room and load room
    private void OnRoomExit(SceneAsset nextRoom, string playerSpawnTransformName)
    {
        GameState.playerSpawnLocation = playerSpawnTransformName;
        SceneManager.LoadScene(nextRoom.name, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        RoomEvents.roomExit -= OnRoomExit;
    }
}
