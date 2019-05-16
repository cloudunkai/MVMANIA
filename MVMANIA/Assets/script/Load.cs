using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{

    
    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            //LoadNewScene();
        SceneManager.LoadScene(1);

        }
    }
    //public void LoadNewScene()
    //{
    //    Globe.nextSceneName="1";
    //    SceneManager.LoadScene("Loading");
    //}
}