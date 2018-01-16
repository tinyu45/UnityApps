using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Material mat = GetComponent<MeshRenderer> ().material;
		//Material mat = GetComponent<Renderer> ().material;
		mat.mainTextureOffset += new Vector2 (0, -0.01f);
	}
}
