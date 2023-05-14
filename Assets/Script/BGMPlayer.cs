using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip BGM;
    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void BGMSound(string sceneName)
    {
        switch (sceneName)
        {
            case "Stage1":
                audioSource.clip = BGM;
                break;
        }
        audioSource.Play();
    }
}