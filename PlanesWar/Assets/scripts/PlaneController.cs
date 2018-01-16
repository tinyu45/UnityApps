using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public GameObject bulletPoint;

	public float fsdel=0.5f;

	private float timer=0;
	// Use this for initialization
	void Start () {
        //InvokeRepeating("fashe", 0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
		fashe (GameController.isPlaying);

        if (this.transform.position.x < -2.43f)
        {
            this.transform.position = new Vector2(-2.43f, transform.position.y);
        }
        else if (this.transform.position.x > 2.37f)
        {
            this.transform.position = new Vector2(2.37f, transform.position.y);
        }
	}


    //发射子弹
	void fashe(bool sheji) {
		if (sheji) {
			timer += Time.deltaTime;
			if (timer >= fsdel) {
				Object obj = Resources.Load ("bullet");
				GameObject bullet = GameObject.Instantiate (obj) as GameObject;
				bullet.transform.position = bulletPoint.transform.position;
				timer = 0;
			} 
		}
    }


}
