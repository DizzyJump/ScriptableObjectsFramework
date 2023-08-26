using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Values;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework
{
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
}
