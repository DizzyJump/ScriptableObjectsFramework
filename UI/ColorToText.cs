using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Values;
using TMPro;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    public class ColorToText : MonoBehaviour
    {
        TextMeshProUGUI text;
        public ColorValue Color;

        private void OnEnable()
        {
            if(text == null)
                text = GetComponent<TextMeshProUGUI>();
            if(Color != null)
            {
                Color.AddHandler(OnChangeValue);
            }
            OnChangeValue();
        }

        private void OnDisable()
        {
            if(Color != null)
                Color.RemoveHandler(OnChangeValue);
        }

        void OnChangeValue()
        {
            if(text != null && Color != null)
                text.color = Color.Value;
        }
    }
}
