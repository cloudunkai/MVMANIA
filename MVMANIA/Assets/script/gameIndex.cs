using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class gameIndex : MonoBehaviour
{
    [SerializeField]
    VideoClip[] gamevideoclip;
    VideoPlayer videoPlayer;
    VideoReader _VideoReader;
    
    void Start()
    {
        gamevideoclip = Resources.LoadAll<VideoClip>("Video/");
        videoPlayer.clip = gamevideoclip[_VideoReader.n];
        videoPlayer.Play();
    }


   
}
