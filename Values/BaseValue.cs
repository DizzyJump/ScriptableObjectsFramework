using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BaseValue<T> : EventObject {
    [SerializeField]
    [OnValueChanged("Invoke")]
    private T value;

    [SerializeField]
    private bool DropOnEnable = false;

    [EnableIf("DropOnEnable")]
    [SerializeField]
    private T DefaultValue;

    public T Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
            Invoke();
        }
    }

    private void OnEnable()
    {
        if(DropOnEnable)
            value = DefaultValue;
    }

    [Button]
    void SetValue(T val)
    {
        Value = val;
    }
}
