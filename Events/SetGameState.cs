using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Events
{
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
}
