using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.RuntimeSets
{
    public class GameObjectRuntimeSetHandler : MonoBehaviour
    {
        [SerializeField] private GameObjectsRuntimeSet[] sets;

        void OnEnable()
        {
            for(int i=0; i<sets.Length; i++)
                sets[i].Add(gameObject);
        }

        void OnDisable()
        {
            for(int i = 0; i < sets.Length; i++)
                sets[i].Remove(gameObject);
        }
    }
}
