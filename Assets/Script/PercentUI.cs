using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentUI : MonoBehaviour
{
    [SerializeField] private Text[] percentText = new Text[3];

    void Start()
    {
        for (int i = 0; i < percentText.Length; i++)
        {
            int clearPer = (int)PlayerPrefs.GetFloat($"stageClearPercent{i + 1}");
            clearPer = Mathf.Min(clearPer, 100);
            percentText[i].text = "Å¬¸®¾î·ü: " + clearPer.ToString() + "%";
        }
    }
}