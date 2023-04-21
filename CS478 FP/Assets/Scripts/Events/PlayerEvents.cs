using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Static events related to the player
public class PlayerEvents
{
    public static UnityAction<Transform> onPlayerSpawned;
    public static UnityAction onPlayerDespawned;
}
