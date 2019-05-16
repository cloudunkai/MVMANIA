using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoReader : MonoBehaviour {

    [SerializeField]
  public  VideoClip[] videoclip;
    VideoPlayer videoplayer;
 　//TV透明度変数
    SpriteRenderer x;
    int index;
   public int n = 1;
    float m = 0;
    //PAUSE
    bool ispause = true;
    public enum VideoButton
    {
        CURRENT,
        NEXT,
        PREV,
    }
    void Start()
    {
        //Resources内のVideoフォルダのすべてのヴィデオを読み込み
        videoclip = Resources.LoadAll<VideoClip>("Video/");
        videoplayer = GetComponent<VideoPlayer>();
        x = GameObject.Find("Square").GetComponent<SpriteRenderer>();
        
    }

    void Update () {
        
        alpha();
        //ヴィデオの数
        //SpaceでPlay/PAUSE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vbutton(VideoButton.CURRENT);
        }
        //アローキーでビデオチェンジ
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            vbutton(VideoButton.PREV);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            vbutton(VideoButton.NEXT);
        }
    }
    void alpha()
    {
        //TVヴィデオ画面の透明度
        if (videoplayer.isPlaying)
        {
            ispause = false;
            m += 0.003f;
            x.color = new Color(1, 1, 1, m);
            if (m >= 0.8f) m = 0.8f;
        }
        //else
        //{
        //    m -= 0.005f;
        //    x.color = new Color(1, 1, 1, m);
        //    if (m <= 0) m = 0;
        //}
    }
    public void vbutton(VideoButton vb)
    {
        index = videoclip.Length;
        switch (vb)
        {
            case VideoButton.CURRENT:
                videoplayer.clip = videoclip[index - n];
                ispause = !ispause;
                if (ispause) videoplayer.Pause();
                else videoplayer.Play();
                break;

            case VideoButton.NEXT:
                m = 0;
                ispause = false;
                n--;
                if (n < 1)
                {
                    n = index;
                }
                videoplayer.clip = videoclip[index - n];
                videoplayer.Play();
                break;
            case VideoButton.PREV:
                m = 0;
                ispause = false;
                n++;
                if (n > index)
                {
                    n = 1;
                }
                videoplayer.clip = videoclip[index - n];
                videoplayer.Play();
                break;
        }
    }
}
