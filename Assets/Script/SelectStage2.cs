using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage2 : MonoBehaviour
{
    public void Stage4()
    {
        SceneManager.Instance.LoadScene("Stage4");
    }
    public void Stage5()
    {
        SceneManager.Instance.LoadScene("Stage5");
    }
    public void Stage6()
    {
        SceneManager.Instance.LoadScene("Stage6");
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
                SceneManager.Instance.LoadScene("SelectStage3");
            else if (Input.GetAxis("Horizontal") < 0)
                SceneManager.Instance.LoadScene("SelectStage");
        }

        if (Input.GetButtonDown("Cancel"))
            SceneManager.Instance.LoadScene("Start");
    }
}