using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public float jump = 10f;
    public float rotationSpeed = 180f;

    public bool isJumping = false;
    public bool isRotating = false;
    public bool isMouseDown = false;

    private Rigidbody2D rigid;

    [SerializeField] private AudioClip audioJump;
    [SerializeField] private AudioClip audioDamaged;
    [SerializeField] private AudioClip audioFinish;
    [SerializeField] private AudioClip audioItem;

    [SerializeField] private AudioSource audioSource; // 플레이어는 본인이 가져야 하는 이유가 있음

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);

        if (isJumping)
            rigid.rotation -= rotationSpeed * Time.deltaTime;

        isMouseDown = IsButtonDown();
        isRotating = IsRotate();

        if (isMouseDown && !isJumping && !isRotating)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            isJumping = true;
            PlaySound("JUMP");
        }
    }

    private bool IsButtonDown()
    {
#if UNITY_ANDROID
        return Input.touchCount > 0;
#elif UNITY_STANDALONE_WIN
        return Input.GetButtonDown("Jump");
#endif
    }

    private bool IsRotate()
    {
        float z = GetAnglesZ();
        if((z < 7 && z > -7) || (z < 97 && z > 83) || (z < 187 && z > 173) || (z < 277 && z > 263) || (z < 367 && z > 353))
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
            StageManager.Instance.OnDieStage(transform.position);
            StageManager.Instance.GenerateRespawnPlayer();
            StageManager.Instance.RespawnItems();
            PlaySound("DAMAGED");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            if(PlayerData.Instance.stageNumber == 2)
            {
                PlayerData.Instance.UnlockCharacter(4);
            }
            if(PlayerData.Instance.stageNumber == 3)
            {
                PlayerData.Instance.UnlockCharacter(5);
            }

            StageManager.Instance.OnClearStage();
            // 스테이지 종료를 스테이지 매니저에게 전달
            PlaySound("END");
            SceneManager.Instance.EndStage();
        }

        if (collision.CompareTag("Item"))
        {
            var itemObject = collision.GetComponent<ItemObject>();
            if (itemObject == null)
                return;

            if (itemObject is JumpUpObject)
            {
                // 점프력 업
                jump = 15f;
                Invoke("JumpDown", 2f);
            }
            else if (itemObject is SpeedUpObject)
            {
                // 스피드 업
                speed = 8f;
                Invoke("SpeedDown", 2f);
            }
            else if (itemObject is UnlockObject)
            {
                PlayerData.Instance.UnlockCharacter(3);
            }

            itemObject.gameObject.SetActive(false);
            PlaySound("Item");
        }
    }

    void JumpDown()
    {
        jump = 10f;
    }

    void SpeedDown()
    {
        speed = 4f;
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
            case "Item":
                audioSource.clip = audioItem;
                break;
        }

        audioSource.PlayOneShot(audioSource.clip);
    }

}