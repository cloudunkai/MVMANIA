using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cubecolor : MonoBehaviour
{

    Material _material;
    public Slider fill;
    public Button[] button;
    float i = 1f;
    float r, g, b;
    bool mixchange = false;

    void Start()
    {
        //全体的色変換
        _material = GetComponent<MeshRenderer>().sharedMaterials[0];
        //0秒から毎５秒全体的に色変換
        InvokeRepeating("ChangeColor", 0f, 5f);
    }
    void Update()
    {

        //ButtonColor();
        //毎20秒虹色を変更　10ｓ後戻る
        if (i >= 20)
        {
            mixchange = true;
            ChangeColor();
            if (i >= 30)
            {
                i = 0;
                mixchange = false;
            }
        }
        i += Time.deltaTime;

        Color _color = new Color(r, g, b);
        _material.SetColor("_Color", _color);
    }
    //ランダムで色変更
    void ChangeColor()
    {
        r = Random.Range(0.5f, 1f);
        g = Random.Range(0.5f, 1f);
        b = Random.Range(0.5f, 1f);
    }
    void ButtonColor()
    {
        //buttonとslider色変換、虹色を変更しない
        if (mixchange == false)
        {
            fill.fillRect.transform.GetComponent<Image>().color = new Color(r, g, b);
            button[0].image.color = new Color(r, g, b);
            button[1].image.color = new Color(r, g, b);
        }
        else
        {
            fill.fillRect.transform.GetComponent<Image>().color = new Color(0.5f, 1.0f, 1.0f);
            button[0].image.color = new Color(1, 1, 1);
            button[1].image.color = new Color(1, 1, 1);
        }
    }
}
