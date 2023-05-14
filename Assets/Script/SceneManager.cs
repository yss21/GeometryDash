using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance = null;

    private BGMPlayer bgmPlayer = null;
    private int stageNumber = 0;


    // 프로퍼티
    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    public BGMPlayer BgmPlayer
    { 
        get
        {
            if(bgmPlayer == null)
            {
                bgmPlayer = FindObjectOfType<BGMPlayer>();
            }
            return bgmPlayer;
        }
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        BgmPlayer.BGMSound(sceneName);
    }

    private void SetCurrentStageNumber(int stageNum)
    {
        stageNumber = stageNum;
    }

    public void StartStage(int stageNum)
    {
        SetCurrentStageNumber(stageNum);
        LoadScene("Stage" + stageNum.ToString());
    }

    public void NextStage()
    {
        SetCurrentStageNumber(stageNumber + 1);
        LoadScene("Stage" + stageNumber.ToString());
    }

    public void EndStage()
    {
        LoadScene("End");
    }

}