using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    AudioSource _audioSource;
    public FFTWindow _fftWindow;
    public AudioClip _audioClip;
    //スペクトルデータ
    public static float[] _samples = new float[512];
    public int _samplesCount;
    //Add
    public static float[] _samplesBandBuffer = new float[512];
    float[] _samplesBufferDecrease = new float[512];

    //周波数
    public static float[] _freqBand = new float[8];
    public int _freqBandCount;
    //緩衝
    public static float[] _bandBuffer = new float[8];
    //緩衝量
    float[] _bufferDecrease = new float[8];

    //周波数最高値
    float[] _freqBandHeighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];
    public static float _amplitude, _amplitudeBuffer;
    float _amplitudeHighest = 0;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _audioClip;
            _audioSource.Play();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
        BandBuffer1();
    }
    void BandBuffer()
    {
        for (int g = 0; g < _freqBandCount; ++g)
        {
            if (_freqBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }
    void BandBuffer1()
    {
        for (int g = 0; g < 512; ++g)
        {
            if (_samples[g] > _samplesBandBuffer[g])
            {
                _samplesBandBuffer[g] = _samples[g];
                _samplesBufferDecrease[g] = 0.005f;
            }
            if (_samples[g] < _samplesBandBuffer[g])
            {
                _samplesBandBuffer[g] -= _samplesBufferDecrease[g];
                _samplesBufferDecrease[g] *= 1.2f;
            }
        }
    }
    /// <summary>
    /// 振幅
    /// </summary>
    void GetAmplitude()
    {
        float _currentAmplitude = 0;
        float _currentAmplitudeBuffer = 0;
        for (int i = 0; i < _freqBandCount; i++)
        {
            _currentAmplitude += _audioBand[i];
            _currentAmplitudeBuffer += _audioBandBuffer[i];
        }
        if (_currentAmplitude > _amplitudeHighest)
        {
            _amplitudeHighest = _currentAmplitude;
        }
        _amplitude = _currentAmplitude / _amplitudeHighest;
        _amplitudeBuffer = _currentAmplitudeBuffer / _amplitudeHighest;
    }
    /// <summary>
    /// 周波数を作成
    /// </summary>
    void CreateAudioBands()
    {
        for (int i = 0; i < _freqBandCount; i++)
        {
            if (_freqBand[i] > _freqBandHeighest[i])
            {
                _freqBandHeighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHeighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHeighest[i]);
        }
    }
    /// <summary>
    /// スペクトルデータを取得  
    /// </summary>
    void GetSpectrumAudioSource()
    {
        //スペクトルデータを取得  
        _audioSource.GetSpectrumData(_samples, 0, _fftWindow);
    }
    /// <summary>
    /// 頻度を作成
    /// </summary>
    void MakeFrequencyBands()
    {
        /* サンプリング率22050を想定して、512サンプルを取得 した
         * 22050 / 512 = 43HZ/サンプル
         * 20 - 60 HZ
         * 60 - 250 HZ
         * 500 - 2000 HZ
         * 2000 - 4000 HZ
         * 4000 - 6000 HZ
         * 6000 - 20000 HZ
         */
        int count = 0;
        for (int i = 0; i < _freqBandCount; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10;
        }
    }

  
}
