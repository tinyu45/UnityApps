using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollController : MonoBehaviour {

	public float scoll_Speed=3f;
	// Use this for initialization
	public Texture[] bgs;

	int index=0;

	void Start () {
		//this.GetComponent<MeshRenderer> ().materials [0].mainTexture = bgs [2];
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

	//换背景
	public void ChangeBg(int index){
		this.GetComponent<Renderer> ().materials [0].mainTexture = bgs [index];
	}
}
