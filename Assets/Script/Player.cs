using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    public float rotationSpeed = 50f;

    private Quaternion previousRotation;

    private bool isJumping = false;
    private Rigidbody2D rigid;

    [SerializeField] private AudioClip audioJump;
    [SerializeField] private AudioClip audioDamaged;
    [SerializeField] private AudioClip audioFinish;

    [SerializeField] private AudioSource audioSource; // �÷��̾�� ������ ������ �ϴ� ������ ����

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);

        if (isJumping)
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && !isJumping && !IsRotate())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            isJumping = true;
            PlaySound("JUMP");
        }
    }
    private bool IsRotate()
    {
        float z = GetAnglesZ();
        if((z < 5 && z > -5) || (z < 95 && z > 85) || (z < 185 && z > 175) || (z < 275 && z > 265))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private float GetAnglesZ()
    {
        return transform.localEulerAngles.z;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isJumping = false;
        if (collision.gameObject.tag == "Enemy")
        {
            StageManager.Instance.GenerateRespawnPlayer();
            PlaySound("DAMAGED");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            // �������� ���Ḧ �������� �Ŵ������� ����
            PlaySound("END");
            SceneManager.Instance.EndStage();
        }
    }
    void PlaySound(string action)
    {
        switch (action)
        {
            case "JUMP":
                audioSource.clip = audioJump;
                break;
            case "DAMAGED":
                audioSource.clip = audioDamaged;
                break;
            case "FINISH":
                audioSource.clip = audioFinish;
                break;
        }

        audioSource.PlayOneShot(audioSource.clip);
    }
}