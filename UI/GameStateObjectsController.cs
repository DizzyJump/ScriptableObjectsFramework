using System.Collections.Generic;
using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Events;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    public class GameStateObjectsController : MonoBehaviour
    {
        [SerializeField] private string Description;
        private GameStateChangeEvent gameStates;
        [SerializeField] private List<GameStates> gameStatesTrigger;
        [SerializeField] private List<GameObject> gameObjectActiveList;
        [SerializeField] private List<GameObject> gameObjectEnableList;
        [SerializeField] private List<GameObject> gameObjectDisableList;
        // Start is called before the first frame update
        void Start()
        {

        }

        void OnEnable()
        {
            gameStates = GameStateChangeEvent.Import();
            gameStates.AddHandler(OnGameStateChange);
            OnGameStateChange();
        }

        void OnDisable()
        {
            gameStates.RemoveHandler(OnGameStateChange);
        }

        void OnGameStateChange()
        {
            bool triggered = gameStatesTrigger.Contains(gameStates.Value);
            if (triggered)
            {
                for(int i=0; i<gameObjectEnableList.Count; i++)
                    gameObjectEnableList[i].SetActive(true);
                for(int j=0; j<gameObjectDisableList.Count; j++)
                    gameObjectDisableList[j].SetActive(false);
            }
            for(int k=0; k<gameObjectActiveList.Count; k++)
                gameObjectActiveList[k].SetActive(triggered);
        }
    }
}
