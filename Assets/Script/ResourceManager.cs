using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FriendlyData
{
    public bool locked;
    public int speed;
    public int jump;
    public int addSpeed;
    public int addJump;
    public int dashSpeed;
}

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;
    public static ResourceManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<ResourceManager>();  
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    private readonly string URL = "https://docs.google.com/spreadsheets/d/1cxM-DWpWsgNaPKaV_FSZcJOnjBueeMPvfRIqjM5lPl4/export?format=csv&gid=";
    private readonly uint friendlyDataCode = 0;

    private Dictionary<int, FriendlyData> friendlyDictionaryByLevel = new Dictionary<int, FriendlyData>();

    protected IEnumerator Start()
    {
        instance = FindObjectOfType<ResourceManager>();
        DontDestroyOnLoad(instance.gameObject);

        // 시트 1. 아군 데이터
        var request = UnityWebRequest.Get(URL + friendlyDataCode);
        yield return request.SendWebRequest();
        // 양보 끝

        DownloadHandler dataHandler = request.downloadHandler;
        var sheetList = CSVReader.Read(dataHandler.text);

        foreach (var column in sheetList)
        {
            FriendlyData _data = new FriendlyData()
            {
                locked = (int)column["locked"] > 0,
                speed = (int)column["speed"],
                jump = (int)column["jump"],
                addSpeed = (int)column["addSpeed"],
                addJump = (int)column["addJump"],
                dashSpeed = (int)column["dashSpeed"]
            };

            int id = (int)column["id"];

            if (!friendlyDictionaryByLevel.ContainsKey(id))
                friendlyDictionaryByLevel.Add(id, _data);
        }

        SceneManager.Instance.LoadScene("Start");
    }

    public FriendlyData GetFriendlyDataByLevel(int id)
    {
        if (friendlyDictionaryByLevel.ContainsKey(id))
        {
            return friendlyDictionaryByLevel[id];
        }

        return null;
    }
}