using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LRC : MonoBehaviour {

	//public Text uiText;  ui显示
	public TextAsset txt;  //控制台输出

	public float startTime; //系统开始时间
	public float currentTime;//当前时间

	public float[] lrcTime;
	public string[] lrcs;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (800, 450, false);
	}


	// Update is called once per frame
	void Update () {
		/*
		currentTime = Time.time;
		string curLrc = getLrc (currentTime - startTime);
		if(uiText.text=="" || uiText.text!=curLrc)
		uiText.text=curLrc;
		*/
	}



	public void initLrc()
	{
		string lrc = txt.text;   //歌词初始化；
		startTime=Time.time;

		string[] arr=lrc.Split ('\n');
		lrcs=new string[arr.Length];
		lrcTime=new float[arr.Length];
		string temp;
		float minu;
		float seconds;
		for (int i = 0; i < arr.Length; i++) 
		{
			lrcs [i] = arr [i].Substring(arr [i].IndexOf(']')+1); //初始化歌词
			temp= arr [i].Substring (1, arr [i].IndexOf (']')-1);
			string[] curtime=temp.Split (':');
			minu = float.Parse(curtime [0]);
			seconds= float.Parse (curtime [1]);
			lrcTime [i] = minu * 60 + seconds;
		}
	}



	public string getLrc(float time)
	{
		int x = (int)time;
		int y;
		int z;
		for(int i=0; i<lrcTime.Length; i++)
		{
			y=(int)lrcTime [i];
			z=(int)lrcTime [i + 1];
			if(x>=y && x<=z)
			{
				return lrcs[i];
			}
		}
		return "暂无歌词";
	}

}
