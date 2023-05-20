using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] private GameObject soundSettingPopup = null;
    [SerializeField] private GameObject characterSelectPopup = null;

    private void Start()
    {
        PlayerData.Instance.characterNumber = ReadCharacterNumber();
    }

    public void OnClickStart()
    {
        SceneManager.Instance.LoadScene("SelectStage");
    }

    public void OnClickCharacterSetting(bool isActive)
    {
        characterSelectPopup.SetActive(isActive);
    }

    public void OnClickSoundSetting(bool isActive)
    {
        soundSettingPopup.SetActive(isActive);
    }

    public int ReadCharacterNumber()
    {
        return PlayerPrefs.GetInt("characterNumber");
    }
}