using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    [SerializeField]
    private RoomConnection _connection;

    [SerializeField]
    private string _targetSceneName;

    [SerializeField]
    private Transform _spawnPoint;

    private void Start()
    {
        if (_connection == RoomConnection.ActiveConnection)
        {
            FindObjectOfType<GridMoveset>().transform.position = _spawnPoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<GridMoveset>();
        if (player != null)
        {
            RoomConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_targetSceneName);
        }

        
    }
}
