using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpriteToImageSet : MonoBehaviour {
    public SpriteValue Sprite;
	// Use this for initialization
	void Start () {
        GetComponent<Image>().sprite = Sprite.Value;
	}
}
