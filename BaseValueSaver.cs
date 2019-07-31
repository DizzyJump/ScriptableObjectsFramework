using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseValueSaver<TYPE, HOLDER> : MonoBehaviour where HOLDER : BaseValue<TYPE>
{
    public HOLDER Value;
    public StringValue Key;
    public bool LoadOnAwake;
    public TYPE DefaultValue;

    private void Awake()
    {
        if(LoadOnAwake)
        {
            if(PlayerPrefs.HasKey(Key.Value))
                Value.Value = LoadValue();
            else
                Value.Value = DefaultValue;
        }
    }

    public abstract TYPE LoadValue();
    public abstract void SaveValue();

    public void OnUpdateValue()
    {
        SaveValue();
        PlayerPrefs.Save();
    }
}
