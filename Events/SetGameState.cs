using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameState : MonoBehaviour
{
    private GameStateChangeEvent gameState;

    [SerializeField] private GameStates targetState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameStateChangeEvent.Import();
        
    }

    public void SwitchState()
    {
        gameState.Value = targetState;
    }
}
