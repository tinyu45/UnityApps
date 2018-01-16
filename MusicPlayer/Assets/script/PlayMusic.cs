using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour {

	public AudioSource source;
	public LRC lrc;
	public Text uiText;
	public Slider progress;
	public Button play;
	public Image singerPic;
	public Image RotateTool;
	public Slider Volunce;

	public bool isDraged = false;




	// Use this for initialization
	void Start () {
		lrc.initLrc ();
		progress.maxValue = source.clip.length; //歌曲总时长
	}
	
	// Update is called once per frame

	void Update () {
		string curLrc=lrc.getLrc (source.time);
		if (uiText.text == "" || uiText.text != curLrc) 
		{
			uiText.text=curLrc;
		}

		if (!isDraged) {
			progress.value = source.time;
		} 

			
		if (source.isPlaying) 
		{
			singerPic.transform.Rotate(0,0,0.3f);
		}

	}


	public void OnPlayBtnClick()
	{
		if (source.isPlaying) 
		{
			source.Pause ();
			RotateTool.transform.Rotate (0, 0, 30);
		} 
		else 
		{
			source.Play ();
			RotateTool.transform.Rotate (0, 0, -30);
		}
		source.volume = 0.5f;
		Volunce.value = source.volume;
	}



	public void volunceChange()
	{
		source.volume=Volunce.value;
	}


	public void onProgressChanged()
	{
		if (isDraged) 
		{
			
		}
	}


	public void onDragStart()
	{
		isDraged = true;
		source.Pause ();
		//print ("开始拖动了！");

	}

	public void onDrogStop()
	{
		isDraged = false;
		source.time = progress.value;
		source.Play ();

		///print ("拖动停止");
	}







}
