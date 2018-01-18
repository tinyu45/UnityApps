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
		FIRST,
		PAUSE,
		PLAYING
	}

	public static string[,] enemys;

	public GAMESTATE state;

	public static bool isPlaying=false;

	public static bool hasReword=false;

	///private bool huogaun=false;
	public int gs=1;

	//分数显示UI;
	public Text scoreBox;
	public Button pause_btn;

	[HideInInspector]  //面板隐藏
	public int score = 0;

    public GameObject plane;   //我方飞机

	public static int reward=0;

    public float speed = 1;

	float timer=0;

	float rewardTime=0;

	float demusic=0;

    // Use this for initialization
    void Start () {
		gs = 1;
		reward = 0; //开局为0
		demusic=0;
		state = GAMESTATE.FIRST;
		enemys = new string[4,5] {
			{ "enemy5","enemy4", "enemy","enemy5","enemy4"},
			{"enemy4","enemy4","enemy","enemy3","enemy"},
			{"enemy5","enemy4", "enemy","enemy3", "enemy2"},
			{"enemy3","enemy4", "enemy","enemy3", "enemy2"}
		};
		InvokeRepeating("GennerateBaoVox", 0, 20);
		GetComponent<AudioManger> ().PlaySound ("readygo");
	}
	
	// Update is called once per frame
	void Update () {
		if (demusic <= 2 && state==GAMESTATE.FIRST) {
			demusic+=Time.deltaTime;
		} else if(state!=GAMESTATE.PAUSE){
			isPlaying = true;
			state = GAMESTATE.PLAYING;
		}

		if (isPlaying) {
			GetComponent<AudioManger> ().PlayMusic ("bgm_kaichangdonghua");
			createEnemy (); //生成敌人
			if (hasReword) {
				plane.GetComponent<PlaneController> ().changeface (reward);
				hasReword = false;
				rewardTime = 0;
			} else {
				if((reward>0)&&(rewardTime <=(2-reward)*15+5)){
					if (reward > 2) {
						reward = 0;
						rewardTime = 0;
					}
					rewardTime += Time.deltaTime;
				} else if(rewardTime>(2-reward)*15+5){
					reward--;
					hasReword = true;
				}
			} 



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
		//print (enemys.GetLength (1));
		string enemyName=enemys[gs-1,Random.Range (0, enemys.GetLength(1))];
		timer += Time.deltaTime;
		if (timer >= 2) {
			Object obj = Resources.Load(enemyName);
			GameObject enemy = Instantiate(obj) as GameObject;
			timer = 0;
		} 
	}

	void GennerateBaoVox(){
		Object obj = Resources.Load ("baovox");
		Instantiate (obj);
	}
    

	//更新分数
	public void updateScore(int attack){
		score += 5;
		switch (score) {
		case 200:
			FindObjectOfType<BGScrollController> ().ChangeBg (1);  //换场景
			AudioManger.Instance.ChangeMusic ("bgm_zhandou1"); 
			gs = 2;
			break;
		case 400:
			FindObjectOfType<BGScrollController> ().ChangeBg (2);
			AudioManger.Instance.ChangeMusic ("bgm_kaichangdonghua");
			gs = 3;
			break;
		case 800:
			FindObjectOfType<BGScrollController> ().ChangeBg (3);
			AudioManger.Instance.ChangeMusic ("bgm_zhandou2");
			gs = 4;
			break;
		default: break;
		}
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
			return 5;
		case"enemy4":
			return 3;
		case"enemy3":
			return 8;
		case"enemy2":
			return 12;
		default:
			return 2;
		}
	}


}
