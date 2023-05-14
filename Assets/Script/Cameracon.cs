using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracon : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform을 받아올 변수

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        transform.position = playerTransform.position + offset; // 카메라 위치를 플레이어 위치에 더해주면서 거리 차이를 유지
        transform.rotation = Quaternion.Euler(0, 0, 0); // 카메라 회전을 고정
    }
}
