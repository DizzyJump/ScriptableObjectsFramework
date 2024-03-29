﻿using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Values;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework
{
	public class RenderPosition : MonoBehaviour {
		public Vector3Value position;
		Transform _transform;
		public Vector3 offset = Vector3.zero;
		// Use this for initialization
		void Start () {
			_transform = transform;
		}
	
		// Update is called once per frame
		void LateUpdate () {
			_transform.position = position.Value + offset;
		}
	}
}
