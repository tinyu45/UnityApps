using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombController : MonoBehaviour {

    public Sprite[] bombs;
    private float timer = 0;
    private int index = 0;
    public float fps = 0.5f; //帧率
    private float liveTime = 0.8f; //存活时间

	// Use this for initialization
	void Start () {
        //获取组件 切换图片
        //bomb.GetComponent<SpriteRenderer>().sprite= bombs[2];
	}
	
	// Update is called once per frame
	void Update () {
		
		Play (GameController.isPlaying);
    }


	void Play(bool canplay){
		if (canplay) {
			timer += Time.deltaTime;
		}
		if (timer>=liveTime)
		{
			//销毁
			Destroy(this.gameObject);   
		}
		else {
			if (index == bombs.Length)
			{
				timer = 0;
				index = 0;
			}
			else
			{
				if (timer >= index / fps)
				{
					this.GetComponent<SpriteRenderer>().sprite = bombs[index];
					index++;
				}
			}
		}
	}
   

}
