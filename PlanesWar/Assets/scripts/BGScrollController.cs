using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollController : MonoBehaviour {

	public float scoll_Speed=3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ScrollBg ();
	}

	public void ScrollBg(){
		if (GameController.isPlaying) {
			this.GetComponent<MeshRenderer> ().material.mainTextureOffset += new Vector2 (0, scoll_Speed)*Time.deltaTime/5;
		}
	}
}
