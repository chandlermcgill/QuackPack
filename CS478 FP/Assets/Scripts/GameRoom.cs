using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoom : MonoBehaviour
{
    public Transform defaultPlayerSpawn;

    //Start the game level
    private void Start()
    {
        RoomEvents.roomLoaded.Invoke(defaultPlayerSpawn);
    }
}
