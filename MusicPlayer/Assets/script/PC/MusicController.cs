using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    //音频资源
    public AudioSource audioSrc;
    public AudioClip[] musics;

    //播放相关按钮
    public Button start;
    public Button prev;
    public Button next;

    //播放键图标
    public Sprite playIcon;
    public Sprite pauseIcon;

    //歌手头像
    public Sprite[] singers;
    public Image singerbox;

    private int curIndex = 0;
    private bool isFirst = true;

    //计时器
    private float timer = 0;

    //cd
    public Image cd;
    public GameObject point;
    public Image tou;

    //歌词成员

    // Use this for initialization
    void Start () {
        curIndex = 0;
        singerbox.sprite = singers[curIndex];
        tou.transform.RotateAround(point.transform.position, new Vector3(0,0,1), 20);
    }
	
	// Update is called once per frame
	void Update () {
        if (timer >= audioSrc.clip.length)
        {
            timer = 0;
            OnNextBtnClick();//下一首
        }
        else if(audioSrc.isPlaying){
            timer += Time.deltaTime;
            cd.transform.Rotate(new Vector3(0,0,1)*Time.deltaTime*8);
            FindObjectOfType<LrcController>().ShowLrc(timer);
        }
        
        
	}

    //播放按钮点击事件
    public void OnStartBtnClick() {
        if (audioSrc.isPlaying)
        {
            audioSrc.Pause();  //暂停
            tou.transform.RotateAround(point.transform.position, new Vector3(0, 0, 1), 20);
            FindObjectOfType<LrcController>().isPlaying = false;
            start.GetComponent<Image>().sprite = playIcon;
        }
        else {
            audioSrc.Play();  //播放
            tou.transform.RotateAround(point.transform.position, new Vector3(0, 0, 1), -20);
            if (isFirst)
            {
                FindObjectOfType<LrcController>().LoadLrc(curIndex); //加载歌词
                isFirst = false;
            }
            FindObjectOfType<LrcController>().isPlaying = true;
            start.GetComponent<Image>().sprite = pauseIcon;
        }
    }

    //上一首按钮点击
    public void OnPrevBtnClick() {
        audioSrc.Pause();
        timer = 0;
        FindObjectOfType<LrcController>().isPlaying = false;
        curIndex = curIndex == 0 ? musics.Length - 1 : curIndex-1;
        FindObjectOfType<LrcController>().LoadLrc(curIndex);
        audioSrc.clip = musics[curIndex];
        singerbox.sprite = singers[curIndex];
        audioSrc.Play();
        FindObjectOfType<LrcController>().isPlaying = true;
    }

    //下一首按钮点击
    public void OnNextBtnClick() {
        audioSrc.Pause();
        timer = 0;
        FindObjectOfType<LrcController>().isPlaying = false;
        curIndex = curIndex == musics.Length - 1 ? 0 : curIndex+1;
        audioSrc.clip = musics[curIndex];
        singerbox.sprite = singers[curIndex];
        FindObjectOfType<LrcController>().LoadLrc(curIndex);
        audioSrc.Play();
        FindObjectOfType<LrcController>().isPlaying = true;
    }
}
