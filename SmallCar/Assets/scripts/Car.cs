﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	//class 类型 封装一类物体的属性、功能(行为)
	// Use this for initialization

	Color cplor=Color.red;  //定义红色
	float weight=500;

	void Start () {
	//		KeyCode.UpArrow //向上方向键    输入包括：鼠标、键盘、触屏、手柄

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3(0, 1, 0)*Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += new Vector3(0, -1, 0)*Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3(-1, 0, 0)*Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1, 0, 0) * Time.deltaTime;
		}

	}

	//移动功能
	void Move(){
		
	}

	//隐身
	void Hide(){
		this.gameObject.SetActive (false);//设置小车隐藏
		GetComponent<SpriteRenderer>().enabled=false;
	}


}
