using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Events
{
    public class ButtonEvent : MonoBehaviour {
        public EventObject Event;
	
        public void OnClick()
        {
            if(Event)
                Event.Invoke();
            else
                Debug.LogError("Event object reference didnt set!");
        }
    }
}
