using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            }
            return instance;
        }
    }

    public Sprite[] characterSprites = new Sprite[6];
    public int characterNumber = 0;
    public int stageNumber = 0;

    public Sprite GetMyCharacterSprite()
    {
        return characterSprites[characterNumber];
    }
}
