using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/***
    敌机控制器
**/
public class EnemyController : MonoBehaviour {
   
    //public GameObject bullet_paint;
    public float EnemySpeed = 0.01f;
	private int attack = 1;
    // Use this for initialization
    void Start () {
		attack=GameController.findAttack (this.gameObject);
        this.transform.position = new Vector3(Random.Range(-2.38f, 2.42f), 4.68f, 0); //随机位置
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.isPlaying){
			this.transform.position += new Vector3(0, -EnemySpeed, 0)*Time.deltaTime;
			//this.transform.Translate(new Vector3(0, EnemySpeed, 0) * Time.deltaTime);
		}
        if (this.transform.position.y <= -5.65) {
            Destroy(this.gameObject);
        }
    }


    //碰撞器   触发器检测
    void OnTriggerEnter2D(Collider2D col2D) {
       // print(col2D.transform.name); //碰到的物体名字
		FindObjectOfType<GameController> ().GetComponent<AudioManger> ().PlaySound ("effcet_sfx_dabaozha");
		if(col2D.gameObject.tag=="Bullet"){
			
			GameObject bomb = Instantiate(Resources.Load("bomb")) as GameObject;  //爆炸动画
			Vector3 bompos=new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-0.3f, 0);
			bomb.transform.position = bompos;
			attack--;
			//print (attack);
			if (attack<=0) {
				FindObjectOfType<GameController> ().updateScore (GameController.findAttack (this.gameObject)*2); //更新得分
				Destroy (this.gameObject);
			}

			//FindObjectOfType<GameController> ().updateScore (4); //加分
			//销毁敌机
			Destroy(col2D.gameObject); //销毁子弹
		}else if(col2D.gameObject.tag=="Plane"){
			//我方飞机与敌方相撞
			//print (col2D.transform.name);
			//print("哈哈哈,你玩完了");
			PlayerPrefs.SetInt("ScoreTotal", FindObjectOfType<GameController>().score);
			SceneManager.LoadScene("Over");
		}
        
    }



    //定时销毁子弹；
    /*
	public int getCanAttack(GameObject enemy){
		print (enemy.transform.name);
		//switch (enemy.transform.name.Substring (0, 6)) {
			
		//}
	} 
	*/


    
}
