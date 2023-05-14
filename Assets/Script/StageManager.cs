using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����
// 1. ��, ĳ���� ���� ����
// 2. ���� �������� ����� ���� > ���� �Ѿ �� �ı��Ǹ� �ȵ� > ���������� �ϴ� ���ҿ� ������
public class StageManager : MonoBehaviour
{
    [SerializeField] private SpawnBehaviour spawner;

    private static StageManager instance = null;

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