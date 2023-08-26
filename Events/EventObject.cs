using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Events
{
    [CreateAssetMenu(menuName = "Game/Events/Base Event")]
    public class EventObject : ScriptableObject {
        public delegate void CustomEvent();
        event CustomEvent OnInvoke = ()=> { };
        [SerializeField] string Description;

        public static T Import<T>(string key) where T : ScriptableObject
        {
            return Resources.Load<T>(key);
        }

        public void Invoke()
        {
            OnInvoke.Invoke();
        }

        public void AddHandler(CustomEvent func)
        {
            OnInvoke += func;
        }

        public void RemoveHandler(CustomEvent func)
        {
            OnInvoke -= func;
        }
    }
}
