using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameState : MonoBehaviour
{
    private GameStateChangeEvent gameState;
    [SerializeField] private GameStates targetState;

    public void Switch()
    {
        if(gameState==null)
            gameState = GameStateChangeEvent.Import();
        gameState.Value = targetState;
    }
}
