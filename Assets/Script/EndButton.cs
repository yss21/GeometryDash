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
        //SceneManager.Instance.LoadScene("Stage");
    }
    public void Select()
    {
        SceneManager.Instance.LoadScene("SelectStage");
    }
}