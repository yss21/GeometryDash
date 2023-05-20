using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmsource;
    [SerializeField] private AudioSource sfxsource;
    [SerializeField] private AudioClip bgmclip;
    [SerializeField] private AudioClip sfxclip;
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
    public void SetVolumeBgm(float value)
    {
        bgmsource.volume = value;

    }
    public void SetVolumeSfx(float value)
    {
        sfxsource.volume = value;
    }
}