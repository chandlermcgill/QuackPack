using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActiveGameState { FreeRoam, Battle}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;

    ActiveGameState state;

    private void Start()
    {
        playerController.OnEncountered += StartBattle;
    }

    void StartBattle()
    {
        state = ActiveGameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (state == ActiveGameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == ActiveGameState.Battle)
        {
            battleSystem.Start();
        }
    }
}
