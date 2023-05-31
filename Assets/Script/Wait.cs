using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public void Continue()
    {
        StageManager.Instance.OffWait();
    }
    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.Instance.RetryStage();
    }
    public void Select()
    {
        Time.timeScale = 1.0f;
        SceneManager.Instance.LoadScene("SelectStage");
    }
}
