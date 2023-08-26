using TMPro;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    public abstract class ValueToTextBase : MonoBehaviour {
        protected TMP_Text text;
        public string Prefix;
        public string Postfix;
        // Use this for initialization
        void OnEnable () {
            UpdateText();
        }

        void UpdateText()
        {
            if(text==null)
                text = GetComponent<TMP_Text>();
            if(Prefix != "" || Postfix != "")
                text.text = Prefix + _GetValueString() + Postfix;
            else
                text.text = _GetValueString();
        }

        public void OnUpdateValue()
        {
            UpdateText();
        }

        protected abstract string _GetValueString();
    }
}
