using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	private static Vector3[] ESPos = new Vector3[4] {
		new Vector3 (-1.6f, 5.58f, 0),
		new Vector3 (-0.58f, 5.58f, 0),
		new Vector3 (0.48f, 5.62f, 0),
		new Vector3 (1.46f, 5.62f, 0)
	};
	// Use this for initialization
	void Start () {
		transform.position = ESPos[Random.Range (0, ESPos.Length)];
	}
	
	// Update is called once per frame
	void Update() {
		transform.position+=new Vector3 (0, -1.5f, 0) * Time.deltaTime;
		if (transform.position.y < -5.6f) {
			Destroy(this.gameObject);
		}
	}



	public void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Car") {
			/***
			 * 可添加动画效果
			 * 记分
			 * */
			Destroy (this.gameObject);  //撞后销毁自身
		}
	}


//	public void OnTriggerEnter(Collider2D col){
//	
//	}
		
}
