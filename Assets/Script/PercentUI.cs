using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentUI : MonoBehaviour
{
    [SerializeField] private Text[] percentText = new Text[3];

    // Start is called before the first frame update
    void Start()
    {
        int stageNumber = PlayerData.Instance.stageNumber;

        float previousValue = 0f;

        if (stageNumber == 1)
        {
            if (previousValue < PlayerPrefs.GetFloat($"stageClearPercent{stageNumber}"))
                previousValue = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber}");

            percentText[0].text = previousValue.ToString();
            percentText[1].text = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber + 1}").ToString();
            percentText[2].text = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber + 2}").ToString();
        }
        else if (stageNumber == 2)
        {
            if (previousValue < PlayerPrefs.GetFloat($"stageClearPercent{stageNumber}"))
                previousValue = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber}");

            percentText[0].text = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber - 1}").ToString();
            percentText[1].text = previousValue.ToString();
            percentText[2].text = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber + 1}").ToString();
        }
        else if (stageNumber == 3)
        {
            if (previousValue < PlayerPrefs.GetFloat($"stageClearPercent{stageNumber}"))
                previousValue = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber}");

            percentText[0].text = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber - 2}").ToString();
            percentText[1].text = PlayerPrefs.GetFloat($"stageClearPercent{stageNumber - 1}").ToString();
            percentText[2].text = previousValue.ToString();
        }
    }
}