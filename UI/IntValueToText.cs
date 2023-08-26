using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Values;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    public class IntValueToText : ValueToTextBase {
        public IntValue Value;

        protected override string _GetValueString()
        {
            return Value.Value.ToString();
        }
    }
}
