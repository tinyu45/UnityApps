using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaovoxController : MonoBehaviour {

	float delTime=0;
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(Random.Range(-2.5f, 2.5f),Random.Range(-1.5f, 2.5f),0);
	}
	
	// Update is called once per frame
	void Update () {
		delTime += Time.deltaTime;
		if (delTime >= 15) {
			Destroy (this.gameObject);  //三秒无人捡起，销毁
		}
	}

	public void OnTriggerEnter2D(Collider2D col2D){
		if (col2D.gameObject.tag == "Plane") {
			Destroy (this.gameObject);
			GameController.hasReword = true;
			GameController.reward++;
			//print ("嘿嘿，捡到宝啦！");
		}
	}
}
