using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.HotkeysTracker
{
	public class HotkeyManagerIdle : MonoBehaviour {
		public HotkeysManager manager;
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
			manager.Idle();
		}
	}
}
