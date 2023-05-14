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
        playerObj = Instantiate(player, defaultSpawnPos, defaultRotation);
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
    public void RespawnPlayer()
    {
        playerObj.transform.position = defaultSpawnPos;
        Rigidbody2D rigid = playerObj.GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
    }
}