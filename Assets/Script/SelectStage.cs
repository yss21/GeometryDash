using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour
{
    public void Stage1()
    {
        SceneManager.Instance.StartStage(1);
    }

    public void Stage2()
    {
        SceneManager.Instance.StartStage(2);
    }

    public void Stage3()
    {
        SceneManager.Instance.StartStage(3);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.Instance.LoadScene("Start");
        }
    }
}