using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ����
// 1. ��, ĳ���� ���� ����
// 2. ���� �������� ����� ���� > ���� �Ѿ �� �ı��Ǹ� �ȵ� > ���������� �ϴ� ���ҿ� ������
public class StageManager : MonoBehaviour
{
    [SerializeField] private SpawnBehaviour spawner;
    private MapObject currentMap;

    private static StageManager instance = null;

    [SerializeField] private GameObject waitPopup;

    // ������Ƽ
    public static StageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StageManager>();
            }

            return instance;
        }
    }

    // ������ �� 

    private void Awake()
    {
        GenerateObject();
        GenerateMap();

        currentMap = FindObjectOfType<MapObject>();
    }

    public void GenerateObject()
    {
        spawner.Spawn();
    }
    public void GenerateMap()
    {
        spawner.MakeMap();
    }
    public void GenerateRespawnPlayer()
    {
        spawner.RespawnPlayer();
    }

    public void OnDieStage(Vector3 characterPos)
    {
        float distanceOfStage = currentMap.distanceOfStage;
        float characterPosX = characterPos.x;

        float percent = characterPosX / distanceOfStage * 100.0f;
        PlayerPrefs.SetFloat($"stageClearPercent{PlayerData.Instance.stageNumber}", percent);
    }

    public void OnClearStage()
    {
        PlayerPrefs.SetFloat($"stageClearPercent{PlayerData.Instance.stageNumber}", 100f);
    }

    public void OffWait()
    {
        Time.timeScale = 1.0f;
        waitPopup.SetActive(false);
    }

    void Update()
    {
        if (IsCancelButtonDown())
        {
            // ���� �˾� �����
            Time.timeScale = 0.0f;
            waitPopup.SetActive(true);
        }
    }

    private bool IsCancelButtonDown()
    {
#if UNITY_ANDROID
        return Input.touchCount > 2;
#elif UNITY_STANDALONE_WIN
        return Input.GetButtonDown("Cancel");
#endif
    }
}