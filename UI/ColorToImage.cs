using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Values;
using UnityEngine;
using UnityEngine.UI;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    public class ColorToImage : MonoBehaviour
    {
        Image Sprite;
        public ColorValue Color;

        private void OnEnable()
        {
            if(Sprite == null)
                Sprite = GetComponent<Image>();
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
            if(Sprite != null && Color != null)
                Sprite.color = Color.Value;
        }
    }
}
