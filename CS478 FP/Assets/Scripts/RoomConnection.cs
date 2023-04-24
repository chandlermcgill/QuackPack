using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rooms/Connection")]
public class RoomConnection : ScriptableObject
{
    public static RoomConnection ActiveConnection { get; set; }
}
