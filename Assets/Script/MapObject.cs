using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    [SerializeField] private int stageNumber = 0;
    [SerializeField] public float distanceOfStage = 0.0f;

    private void Reset()
    {
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        var startObj = GameObject.Find("Start");
        var endObj = GameObject.Find("End");
        if (startObj == null || endObj == null)
        {
            Debug.LogError($"start:{startObj} 혹은 end:{endObj} 를 찾지 못함");
            return;
        }

        float startX = startObj.transform.position.x;
        float endX = endObj.transform.position.x;
        
        distanceOfStage = Mathf.Abs(startX - endX);
    }
}
