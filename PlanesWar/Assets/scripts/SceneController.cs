using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public Button startNew;
	public Button home;
	public Button exit;
	public Text ScoreTotal;
	// Use this for initialization
	void Start () {
		//print (PlayerPrefs.GetInt("ScoreTotal"));
		ScoreTotal.text="总得分："+PlayerPrefs.GetInt("ScoreTotal");
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnStartNewBtnClick(){
		SceneManager.LoadScene ("Main");
	}


	public void OnHomeBtnClick(){
		SceneManager.LoadScene ("Start");
	}

	public void OnExitBtnClick(){
		Application.Quit ();
	}

}
