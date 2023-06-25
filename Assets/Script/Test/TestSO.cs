using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TestSO")]
public class TestSO : ScriptableObject
{
    public int number = 0;

    public int localFileNumber
    {
        get
        {
            return PlayerPrefs.GetInt("number");
        }
        set
        {
            PlayerPrefs.SetInt("number", value);
        }
    }

    public void dd()
    {
        var d = new TestMono();
        var f = new TestMono();
    }
}
