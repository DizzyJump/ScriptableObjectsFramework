using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tools/Hotkey manager")]
public class HotkeysManager : ScriptableObject {
    public delegate void Callback();
    Dictionary<KeyCode, Stack<Callback>> registry = new Dictionary<KeyCode, Stack<Callback>>();

    public void RegisterCallback(KeyCode key, Callback callback)
    {
        if(!registry.ContainsKey(key))
            registry.Add(key, new Stack<Callback>());
        registry[key].Push(callback);
    }

    public void UnregisterCallback(KeyCode key, Callback callback)
    {
        if(registry.ContainsKey(key) && registry[key].Contains(callback))
        {
            var c = registry[key].Pop();
            if(c != callback)
                Debug.LogError("Inconsistent registry of hotkey callbacks");
        }
    }

    public void Idle()
    {
        foreach(var key in registry) // потом оптимизируем
        {
            if(key.Value.Count > 0 && Input.GetKeyUp(key.Key))
                key.Value.Peek()();
        }
    }
}
