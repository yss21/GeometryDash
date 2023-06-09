using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 역할
// 1. 맵, 캐릭터 등을 생성
// 2. 현재 스테이지 기록을 저장 > 씬이 넘어갈 때 파괴되면 안됨 > 스테이지가 하는 역할에 부적합
public class StageManager : MonoBehaviour
{
    [SerializeField] private SpawnBehaviour spawner;
    private MapObject currentMap;

    private static StageManager instance = null;
    [SerializeField] private Text dieText = null;
    [SerializeField] private GameObject waitPopup;

    // 프로퍼티
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

    // 뭔가를 씬 

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

    public void RespawnItems()
    {
        spawner.RespawnItems();
    }

    public void OnDieStage(Vector3 characterPos)
    {
        float distanceOfStage = currentMap.distanceOfStage;
        float characterPosX = characterPos.x;

        float currentPercent = characterPosX / distanceOfStage * 100.0f;

        // 이전 기록을 가지고 와서, 
        float prevPercent = PlayerPrefs.GetFloat($"stageClearPercent{PlayerData.Instance.stageNumber}");

        // 현재 값이랑 비교해서
        if (prevPercent < currentPercent)
        {
            PlayerPrefs.SetFloat($"stageClearPercent{PlayerData.Instance.stageNumber}", currentPercent);
        }
    }

    public void OnClearStage()
    {
        PlayerPrefs.SetFloat($"stageClearPercent{PlayerData.Instance.stageNumber}", 100f);
    }

    private void TurnOff()
    {
        dieText.gameObject.SetActive(false);
    }

    public void DieText()
    {
        dieText.text = "플레이어가 죽었습니다.";
        dieText.color = Color.red;
        dieText.gameObject.SetActive(true);
        Invoke("TurnOff", 2f);
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
            // 팝업 만들기
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