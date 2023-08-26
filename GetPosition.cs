using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Values;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework
{
	public class GetPosition : MonoBehaviour {
		public Vector3Value position_write;
		Transform _transform;
		public bool Local = false;
		// Use this for initialization
		void Start () {
			_transform = transform;
		}
	
		// Update is called once per frame
		void Update () {
			position_write.Value = Local ? _transform.localPosition : _transform.position;
		}
	}
}
