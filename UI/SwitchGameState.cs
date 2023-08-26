using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Events;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
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
}
