using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Values;
using UnityEngine;
using UnityEngine.UI;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
	[RequireComponent(typeof(Image))]
	public class SpriteToImageSet : MonoBehaviour {
		public SpriteValue Sprite;
		// Use this for initialization
		void Start () {
			GetComponent<Image>().sprite = Sprite.Value;
		}
	}
}
