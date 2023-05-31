using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance = null;

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

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private void SetCurrentStageNumber(int stageNum)
    {
        PlayerData.Instance.stageNumber = stageNum;
    }

    public void StartStage(int stageNum)
    {
        SetCurrentStageNumber(stageNum);
        LoadScene("Stage" + stageNum.ToString());
    }

    public void RetryStage()
    {
        SetCurrentStageNumber(PlayerData.Instance.stageNumber);
        LoadScene("Stage" + PlayerData.Instance.stageNumber.ToString());
    }

    public void NextStage()
    {
        SetCurrentStageNumber(PlayerData.Instance.stageNumber + 1);
        LoadScene("Stage" + PlayerData.Instance.stageNumber.ToString());
    }

    public void EndStage()
    {
        LoadScene("End");
    }

}