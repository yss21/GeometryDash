using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private const string BGMPlayerPrefKey = "BGM";
    private const string SFXPlayerPrefKey = "SFX";
    // Start is called before the first frame update
    void Start()
    {
        // 이전에 저장된 볼륨 값 로드
        float savedBgmVolume = PlayerPrefs.GetFloat(BGMPlayerPrefKey);
        float savedSfxVolume = PlayerPrefs.GetFloat(SFXPlayerPrefKey);

        // 슬라이더 값 설정
        bgmSlider.value = savedBgmVolume;
        sfxSlider.value = savedSfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.Instance.SetVolumeBgm(bgmSlider.value);
        SoundManager.Instance.SetVolumeSfx(sfxSlider.value);
    }
}
