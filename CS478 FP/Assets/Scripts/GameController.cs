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
        playerController.OnEncountered += StartDaBattle;
        battleSystem.OnBattleOver += EndDaBattle;
    }

    public void StartDaBattle()
    {
        state = ActiveGameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

        battleSystem.StartBattle();
    }

    void EndDaBattle(bool won)
    {
        state = ActiveGameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (state == ActiveGameState.FreeRoam)
        {
            playerController.Update();
        }

        else if (state == ActiveGameState.Battle)
        {
            battleSystem.StartBattle();
        }
    }
}
