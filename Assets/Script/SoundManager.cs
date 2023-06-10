using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmsource;
    private float sfxVolumeValue = 0.0f;

    private const string BGMPlayerPrefKey = "BGM";
    private const string SFXPlayerPrefKey = "SFX";

    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    private void Awake()
    {
        //최초의 볼륨을 몇으로 할지 정하기 위해서
        bgmsource.volume = PlayerPrefs.GetFloat(BGMPlayerPrefKey);

        instance = FindObjectOfType<SoundManager>();
        DontDestroyOnLoad(instance.gameObject);
    }

    public void SetVolumeBgm(float value)
    {
        bgmsource.volume = value;
        PlayerPrefs.SetFloat(BGMPlayerPrefKey, value);
    }

    public void SetVolumeSfx(float value)
    {
        sfxVolumeValue = value; 
        PlayerPrefs.SetFloat(SFXPlayerPrefKey, value);
    }

    public float GetSFXVolume()
    {
        return sfxVolumeValue;
    }

}