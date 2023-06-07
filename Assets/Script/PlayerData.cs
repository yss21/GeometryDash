using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerData > ���α׷��� ���� > ���α׷��� ���� Ű�� �ʱ� ���·� > ����
// PlayerPrefs > ��� ���ÿ� ���� > ���α׷��� ���� > ����

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    private static PlayerData instance = null;
    public static PlayerData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<PlayerData>("PlayerData");

                int char3 = PlayerPrefs.GetInt($"character3");
                instance.characterLock[3] = char3 == 1 ? true : false;

                int char4 = PlayerPrefs.GetInt($"character4");
                instance.characterLock[4] = char4 == 1 ? true : false;

                int char5 = PlayerPrefs.GetInt($"character5");
                instance.characterLock[5] = char5 == 1 ? true : false;
            }
            return instance;
        }
    }

    public Sprite[] characterSprites = new Sprite[6];
    public int characterNumber = 0;
    public int stageNumber = 0;

    public bool[] characterLock = new bool[6]
    {
        true, true, true, false, false, false
    };

    public void UnlockCharacter(int index)
    {
        characterLock[index] = true;
        PlayerPrefs.SetInt($"character{index}", 1);
    }

    public Sprite GetMyCharacterSprite()
    {
        return characterSprites[characterNumber];
    }
}
