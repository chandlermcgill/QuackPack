using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class RoomEvents
{
    //Vector3 location for spawn
    public static UnityAction<Transform> roomLoaded;

    //String name of target transform to spawn player at in new level
    public static UnityAction<SceneAsset, string> roomExit;
}
