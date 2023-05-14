using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 역할
// 1. 맵, 캐릭터 등을 생성
// 2. 현재 스테이지 기록을 저장 > 씬이 넘어갈 때 파괴되면 안됨 > 스테이지가 하는 역할에 부적합
public class StageManager : MonoBehaviour
{
    [SerializeField] private SpawnBehaviour spawner;

    private static StageManager instance = null;

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

    private void Awake()
    {
        GenerateObject();
        GenerateMap();
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
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
            SceneManager.Instance.LoadScene("Wait");
    }
}