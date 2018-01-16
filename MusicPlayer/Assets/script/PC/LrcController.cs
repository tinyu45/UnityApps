using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LrcController : MonoBehaviour {
  
    //歌词文件 数组 多个
    public TextAsset[] txts;

    //歌词显示控件
    public Text show;

    
    private int Tindex = 0;

    List<string> lrcs;  //歌词
    List<float> times; //时间
    
    /*
    public enum PLAYSTATE {
        PLAYING,
        PAUSE
    }
    public PLAYSTATE playstate = PLAYSTATE.PAUSE;
    */

    public bool isPlaying=false;

	// Use this for initialization
	void Start () {
        //初始化
        lrcs = new List<string>();
        times = new List<float>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    //解析歌词
    void ParseLrc(int index, ref List<string> lrcs, ref List<float> times) {
        print(index);
        //清空
        lrcs.Clear();
        times.Clear();
        string[] arr = txts[index].text.Split('\n');
        foreach (string str in arr) {
            string[] lineItems = str.Split('[',':',']');
            lrcs.Add(lineItems[3]);
            float time = float.Parse(lineItems[1]) * 60 + float.Parse(lineItems[2]);
            times.Add(time);
        }
    }


    public void LoadLrc(int index) {
        Tindex = 0;   //初始化    //初始化
        ParseLrc(index, ref lrcs, ref times);  //引用传值
    }

    //更新歌词
    public void ShowLrc(float timer) {
        if (Tindex < times.Count) {
            if (timer >= times[Tindex]) {
                show.text = lrcs[Tindex];
                Tindex++;
            }
        }  
    }


}
