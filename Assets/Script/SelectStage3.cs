using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage3 : MonoBehaviour
{
    public void Stage7()
    {
        SceneManager.Instance.LoadScene("Stage7");
    }
    public void Stage8()
    {
        SceneManager.Instance.LoadScene("Stage8");
    }
    public void Stage9()
    {
        SceneManager.Instance.LoadScene("Stage9");
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
                SceneManager.Instance.LoadScene("SelectStage");
            else if (Input.GetAxis("Horizontal") < 0)
                SceneManager.Instance.LoadScene("SelectStage2");
        }

        if (Input.GetButtonDown("Cancel"))
            SceneManager.Instance.LoadScene("Start");
    }
}