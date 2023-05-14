using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracon : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform�� �޾ƿ� ����

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        transform.position = playerTransform.position + offset; // ī�޶� ��ġ�� �÷��̾� ��ġ�� �����ָ鼭 �Ÿ� ���̸� ����
        transform.rotation = Quaternion.Euler(0, 0, 0); // ī�޶� ȸ���� ����
    }
}
