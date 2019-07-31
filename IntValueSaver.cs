using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntValueSaver : BaseValueSaver<int, IntValue> {
    public override int LoadValue()
    {
        return PlayerPrefs.GetInt(Key.Value);
    }

    public override void SaveValue()
    {
        PlayerPrefs.SetInt(Key.Value, Value.Value);
    }
}
