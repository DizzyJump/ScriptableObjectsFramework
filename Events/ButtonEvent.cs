using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
