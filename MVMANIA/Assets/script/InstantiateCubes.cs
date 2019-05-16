using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{

    public AudioVisualizer audioVisualizer;
    public GameObject _sampleCubePrefeb;
    GameObject[] _sampleCubes;
    //半径
    public int _farAwayFromCenter;
    //cube最高値
    public int maxScale;
    //単位高さ
    public float initScale;

    private void Awake()
    {
        _sampleCubes = new GameObject[audioVisualizer._samplesCount];
    }

    private void Start()
    {
        InstantiateCube();
    }

    private void Update()
    {
        for (int i = 0; i < audioVisualizer._samplesCount; i++)
        {
            float newLength;
            if ((AudioVisualizer._samplesBandBuffer[i] * maxScale + initScale) > 0)
            {
                //cube長さの変化表示
                if (Mathf.Abs((AudioVisualizer._samplesBandBuffer[i] * maxScale + initScale) - _sampleCubes[i].transform.localScale.y) < 3f)
                {
                    //長さの範囲値
                    newLength = Mathf.Abs(Mathf.Lerp(_sampleCubes[i].transform.localScale.y, ((AudioVisualizer._samplesBandBuffer[i] * maxScale) + initScale), 0.1f));
                }
                else
                {
                    newLength = Mathf.Abs((AudioVisualizer._samplesBandBuffer[i] * maxScale + initScale));
                }
                _sampleCubes[i].transform.localScale = new Vector3(3, newLength, 3);
            }
        }
    }

    void InstantiateCube()
    {
        for (int i = 0; i < audioVisualizer._samplesCount; i++)
        {
            //インスタンス
            GameObject _instanceSampleCube = Instantiate(_sampleCubePrefeb);
            _instanceSampleCube.transform.parent = this.transform;
            //オブジェクト番号
            _instanceSampleCube.name = "SampleCube " +i;
            //オイラー角環状cube   
            this.transform.eulerAngles = new Vector3(0, -360.0f / audioVisualizer._samplesCount * i, 0);
            //中心からの位置
            _instanceSampleCube.transform.position = Vector3.forward * _farAwayFromCenter;
            _sampleCubes[i] = _instanceSampleCube;
        }
    }
}
