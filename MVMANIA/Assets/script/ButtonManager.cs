using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public Musicreader _Musicreader;
    public VideoReader _VideoReader;
    /// <summary>
    /// Play/Pause
    /// </summary>
    public void AudioPlayAudio()
    {
        _Musicreader.mbutton(Musicreader.MusicButton.CURRENT);
        _VideoReader.vbutton(VideoReader.VideoButton.CURRENT);
    }
    /// <summary>
    /// Next
    /// </summary>
    public void AudioPlayNext()
    {
        _Musicreader.mbutton(Musicreader.MusicButton.NEXT);
        _VideoReader.vbutton(VideoReader.VideoButton.NEXT);
    }
    /// <summary>
    /// Prev
    /// </summary>
    public void AudioPlayPrev()
    {
        _Musicreader.mbutton(Musicreader.MusicButton.PREV);
        _VideoReader.vbutton(VideoReader.VideoButton.PREV);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("game");
    }

}
