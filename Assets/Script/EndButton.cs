using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    public void Next()
    {
        SceneManager.Instance.NextStage();
    }
    public void Retry()
    {
        SceneManager.Instance.RetryStage();
    }
    public void Select()
    {
        SceneManager.Instance.LoadScene("SelectStage");
    }
}