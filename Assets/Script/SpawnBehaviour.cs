using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject map;

    private Vector2 defaultSpawnPos = Vector2.zero;
    private Quaternion defaultRotation = Quaternion.identity;
    private GameObject playerObj;

    public void Spawn()
    {
        SpawnRoutine();
    }
    private void SpawnRoutine()
    {
        StartCoroutine(InstantiateCharacter());
    }
    
    private IEnumerator InstantiateCharacter()
    {
        Sprite sprite = PlayerData.Instance.GetMyCharacterSprite();
        playerObj = Instantiate(player, defaultSpawnPos, defaultRotation);
        playerObj.GetComponent<SpriteRenderer>().sprite = sprite;
        var cameracon = Camera.main.gameObject.GetComponent<Cameracon>();
        cameracon.playerTransform = playerObj.transform;
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
        yield return null;
    }

    public void MakeMap()
    {
        Instantiate(map, defaultSpawnPos, defaultRotation);
    }
    
    public void RespawnItems()
    {
        var itemObjs = FindObjectsOfType<ItemObject>(true);
        for(int i = 0; i < itemObjs.Length; i++)
        {
            var item = itemObjs[i];
            item.gameObject.SetActive(true);
        }
    }

    public void RespawnPlayer()
    {
        playerObj.transform.SetPositionAndRotation(defaultSpawnPos, defaultRotation);
        Rigidbody2D rigid = playerObj.GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
    }
}