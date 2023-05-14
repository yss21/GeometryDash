using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // [SerializeField] Slider bgmSlider = null;

    public void OnClickStart()
    {
        // BGMPlayer.Instance.setvolume(bgmSlider.value);
        SceneManager.Instance.LoadScene("SelectStage");
    }

    public void SaveData(int slot)
    {
        // PlayerPrefs.SetInt("CharacterSlot", slot);
    }

    public void GameStart()
    {
        // PlayerPrefs.GetInt("CharacterSlot");
    }
}