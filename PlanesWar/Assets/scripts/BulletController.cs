using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bullet_speed=1;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Transform trans = this.gameObject.transform;
		if (GameController.isPlaying) {
			trans.Translate(new Vector3(0, bullet_speed*Time.deltaTime, 0));
		}
        if (trans.position.y >= 13.4) {
            Destroy(this.gameObject);
        }
	}


    void DestoryBullet() {

    }

    //碰撞器
    /*
    void OnControllerEnter(Collision2D col) {
        
    }
    */
}
