using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/***
 * 飞机控制器
 * 
 * */
public class GameController : MonoBehaviour {

		//定义游戏状态枚举
	public enum GAMESTATE{
		PLAYING,
		PAUSE,
		OVER

	}

	public static string[] enemys;

	public GAMESTATE state=GAMESTATE.PLAYING;

	public static bool isPlaying=true;

	//分数显示UI;
	public Text scoreBox;
	public Button pause_btn;

	[HideInInspector]  //面板隐藏
	public int score = 0;

    public GameObject plane;   //我方飞机

    public float speed = 1;

	float timer=0;

    // Use this for initialization
    void Start () {
		enemys =new string[]{"enemy5","enemy4","enemy","enemy3","enemy2"};
       // InvokeRepeating("createEnemy", 0, 2);
		GetComponent<AudioManger> ().PlayMusic ("bgm_kaichangdonghua");
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaying) {
			createEnemy (); //生成敌人

			//plane.transform.position = Input.touches [0].position;
			/*
            if (Input.touchCount == 1) {
                
                if (Input.touches[0].phase == TouchPhase.Moved) {
                    float disx = Input.GetAxis("Mouse X");
                    float disy = Input.GetAxis("Mouse Y");

					plane.transform.Translate(new Vector3(disx, disy, 0) * Time.deltaTime);
                }
            }
            */



            
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				plane.transform.Translate (new Vector3 (0, speed, 0) * Time.deltaTime);
				//FindObjectOfType<BGScrollController> ().ScrollBg ();
			}

			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				plane.transform.Translate (new Vector3 (0, -speed, 0) * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				plane.transform.Translate (new Vector3 (-speed, 0, 0) * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				plane.transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
			}
            
		} 
    }



	void createEnemy() {
		string enemyName=enemys[Random.Range (0, enemys.Length)];
		timer += Time.deltaTime;
		if (timer >= 2) {
			Object obj = Resources.Load(enemyName);
			GameObject enemy = Instantiate(obj) as GameObject;
			timer = 0;
		} 
	}
    

	//更新分数
	public void updateScore(){
		score += 5;
		scoreBox.text = "当前得分：" + score;
	}


	//暂停按钮点击事件
	public void OnPauseBtnClick(){
		//print ("要在听了");
		GetComponent<AudioManger>().SwitchPlayState();
		if (state == GAMESTATE.PLAYING) {
			state = GAMESTATE.PAUSE;
			isPlaying=false;
			pause_btn.GetComponentInChildren<Text> ().text = "继续";
		} else if (state == GAMESTATE.PAUSE) {
			state = GAMESTATE.PLAYING;
			isPlaying=true;
			pause_btn.GetComponentInChildren<Text> ().text = "暂停";
		}
	}



	//{"enemy5","enemy4","enemy","enemy3","enemy2"}
	public static int findAttack(Object enemy){
		string name = enemy.name;
		switch (name.Substring (0, name.IndexOf ("("))) {
		case"enemy":
			return 8;
		case"enemy4":
			return 3;
		case"enemy3":
			return 5;
		case"enemy2":
			return 10;
		default:
			return 2;
		}
	}


}
