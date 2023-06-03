using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] private Image[] image = new Image[6];
    [SerializeField] private Image[] selectImage = new Image[6];
    [SerializeField] private Text alertText = null;

    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            image[i].sprite = PlayerData.Instance.characterSprites[i];
        }

        Select();
    }

    private void TurnOffAlert()
    {
        alertText.gameObject.SetActive(false);
    }

    public void OnClick(int value)
    {
        if (PlayerData.Instance.characterLock[value] == false)
        {
            alertText.text = $"{value + 1} ��° ĳ������ �ر��� �ʿ��մϴ�.";
            alertText.gameObject.SetActive(true);
            Invoke("TurnOffAlert", 2f);
            return;
        }

        if (PlayerData.Instance.characterNumber == value)
            return;

        PlayerData.Instance.characterNumber = value;

        WriteCharacterNumber(value);

        Unselect(); // �� ����
        Select(); // ���� �͸� �Ѱڴ�.
    }

    public void WriteCharacterNumber(int slot)
    {
        PlayerPrefs.SetInt("characterNumber", slot);
        PlayerPrefs.Save();
    }

    void Select()
    {
        selectImage[PlayerData.Instance.characterNumber].color = Color.red;
    }

    // ������ �����Ѵ�.
    void Unselect()
    {
        // ��� �̹����� ����Ÿ ������ �ٲ۴�.
        for(int i = 0;i < 6; i++)
        {
            selectImage[i].color = Color.white;
        }
    }
}