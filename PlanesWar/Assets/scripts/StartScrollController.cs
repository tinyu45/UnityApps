using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScrollController : MonoBehaviour {

	public Button start;
	public Button exit;
	public float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3) {
			GetComponent<MeshRenderer> ().material.mainTextureOffset += new Vector2 (0.1f, 0);
			timer = 0;
		}

	}


	public void onStartBtnClick(){
		SceneManager.LoadScene ("Main");
	}


	public void onExitBtnClick(){
		Application.Quit (); //退出
	}
}
