using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Songname : MonoBehaviour
{
    //音楽名
    public GameObject songname;
    public AudioSource audioSource;
    private GameObject go;
    void Start()
    {
    
    } 

    void Update()
    {
        if(audioSource.isPlaying)
        songname.GetComponent<Text>().text = audioSource.clip.name;
    }
}
