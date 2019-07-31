using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
