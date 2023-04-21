using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//Create one at the start of the game or load game and keep active throughout the active game to manager
[CreateAssetMenu(fileName = "PlayerManager", menuName = "ScriptableObjects/Managers/PlayerManager", order = 1)]
public class PlayerManager : ScriptableObject
{
    [SerializeField]
    private GameObject playerPrefab;
    public GameObject ActivePlayer { get; private set; }
    public GameState GameState { get; set; }

    //Tag of transforms that are locations where the player can spawn
    public string spawnTag;

    //Start is called before the first frame update
    private void OnEnable()
    {
        RoomEvents.roomLoaded += SpawnPlayer;
    }

    protected void SpawnPlayer(Transform defaultSpawnTransform)
    {
        if (GameState.playerSpawnLocation != "")
        {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag(spawnTag);
            bool foundSpawn = false;

            foreach (GameObject spawn in spawns)
            {
                //If matching spawn name
                if (spawn.name == GameState.playerSpawnLocation)
                {
                    foundSpawn = true;

                    //Spawn location set, so spawn player there
                    ActivePlayer = Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity);
                    break;
                }
            }
            if (!foundSpawn)
            {
                throw new MissingReferenceException("Could not find the player spawn location with the name " + GameState.playerSpawnLocation);
            }
        }
        else
        {
            //Create instance of player prefab at default spawn location for level
            ActivePlayer = Instantiate(playerPrefab, defaultSpawnTransform.position, Quaternion.identity);
            Debug.Log("Player spawned at default location: " + defaultSpawnTransform);
        }

        if (ActivePlayer)
        {
            //Set camera to look at track player
            PlayerEvents.onPlayerSpawned.Invoke(ActivePlayer.transform);
        }
        else
        {
            throw new MissingReferenceException("No ActivePlayer in PlayerManager. May have failed to spawn!");
        }
    }

    private void OnDisable()
    {
        RoomEvents.roomLoaded -= SpawnPlayer;
    }

}
