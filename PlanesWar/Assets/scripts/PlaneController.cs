using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public GameObject bulletPoint;

	public float fsdel=0.5f;

	private float timer=0;

	public Sprite[] PlaneFaces;

	private string[] bulletstyles;

	private string bulletName="bullet";
	// Use this for initialization
	void Start () {
		bulletstyles = new string[]{ "bullet", "bullet2", "bullet4", "bullet6" };
		bulletName = bulletstyles [0];
		GetComponent<SpriteRenderer>().sprite=PlaneFaces[0];
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

		if (this.transform.position.y < -4.6f) 
		{
			this.transform.position = new Vector2(transform.position.x, -4.6f);
		} 
		else if (this.transform.position.y > 4.6f) 
		{
			this.transform.position = new Vector2(transform.position.x, 4.6f);
		}
	}


    //发射子弹
	void fashe(bool sheji) {
		if (sheji) {
			timer += Time.deltaTime;
			if (timer >= fsdel) {
				//Object obj = Resources.Load ("bullet"); //第一关
				Object obj = Resources.Load (bulletName); //第二关
				//Object obj = Resources.Load ("bullet4"); // 第三关 
				GameObject bullet = GameObject.Instantiate (obj) as GameObject;
				bullet.transform.position = bulletPoint.transform.position;
				timer = 0;
			} 
		}
    }


	public void changeface(int index){
		GetComponent<SpriteRenderer>().sprite=PlaneFaces[index];
		bulletName = bulletstyles [index];
	}

}
