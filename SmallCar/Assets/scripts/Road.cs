using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Road : MonoBehaviour {

	float timer;
	float delGenEnemy=3;
	float score;
	// Use this for initialization
	void Start () {
		timer = 0;

	}
	
	// Update is called once per frame
	void Update () {
		Material mat = GetComponent<MeshRenderer> ().material;
		//Material mat = GetComponent<Renderer> ().material;
		mat.mainTextureOffset += new Vector2 (0, -0.5f)*Time.deltaTime;

		if (timer < delGenEnemy) {
			timer += Time.deltaTime;
		} else {
			GenerateEnemy ();
			timer = 0;
		}
	}


	private void GenerateEnemy(){
		Instantiate (Resources.Load ("enemy"));  //生成敌人车
	}


	public void addScore(int fz){
		score += fz;
		if (fz > 10000) {
			SceneManager.LoadScene ("场景名");
		}
	}


	public void gameover(){
		PlayerPrefs.SetInt ("数据名",1);
	}


	public void exit(){
		Application.Quit ();//退出游戏
	}

}
