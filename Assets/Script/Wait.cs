using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public void Continue()
    {
        //SceneManager.Instance.LoadScene("");
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
