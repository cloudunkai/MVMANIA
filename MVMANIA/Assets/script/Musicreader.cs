using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Musicreader : MonoBehaviour
{
    [SerializeField]
    AudioClip[] musics;
    AudioSource audiosource;

    int index;
    int n = 1;
    bool ispause = true;
    //Music　Slider
    public Slider audioTimeSlider;
    public enum MusicButton
    {
        CURRENT,
        NEXT,
        PREV,
    }
    void Start()
    {
        //Musicフォルダの音楽を読み込み
        musics = Resources.LoadAll<AudioClip>("Music/");
        audiosource = GetComponent<AudioSource>();
       
    }
    void Update()
    {
        //曲の数
        index = musics.Length;
        //一曲の時間を表現するSlider
        audioTimeSlider.value = audiosource.time / musics[index - n].length;
        //PAUSEとPlay
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mbutton(MusicButton.CURRENT);
        }
        //前の曲
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mbutton(MusicButton.PREV);
        }
        //次の曲
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mbutton(MusicButton.NEXT);
        }
        //Exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void mbutton(MusicButton mb)
    {
        switch (mb)
        {
            case MusicButton.CURRENT:
                audiosource.clip = musics[index - n];
                ispause = !ispause;
                if (ispause) audiosource.Pause();
                else audiosource.Play();
                break;
          
            case MusicButton.NEXT:
                ispause = false;
                n--;
                if (n < 1)
                {
                    n = index;
                }
                audiosource.clip = musics[index - n];
                audiosource.Play();
                break;
            case MusicButton.PREV:
                ispause = false;
                n++;
                if (n > index)
                {
                    n = 1;
                }
                audiosource.clip = musics[index - n];
                audiosource.Play();
                break;
        }
    }
}
