using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntValueToText : ValueToTextBase {
    public IntValue Value;

    protected override string _GetValueString()
    {
        return Value.Value.ToString();
    }
}
