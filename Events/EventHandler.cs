using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour {
    public EventObject dispatcher;
    public UnityEvent Trigger;
	// Use this for initialization
	void OnEnable () {
        if(dispatcher != null)
            dispatcher.AddHandler(OnFireEvent);
    }

    public void Init(EventObject tracking_event, UnityAction callback)
    {
        if(Trigger == null)
            Trigger = new UnityEvent();
        dispatcher = tracking_event;
        Trigger.AddListener(callback);
    }

    private void OnDisable()
    {
        if(dispatcher!=null)
            dispatcher.RemoveHandler(OnFireEvent);
    }

    void OnFireEvent()
    {
        Trigger.Invoke();
    }

    public static void CreateHandler(GameObject game_object, EventObject tracking_event, UnityAction callback)
    {
        var handler = game_object.AddComponent<EventHandler>();
        handler.enabled = false;
        handler.Init(tracking_event, callback);
        handler.enabled = true;
    }
}
