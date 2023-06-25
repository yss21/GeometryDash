using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentSpeed = 0;
    public int currentJump = 0;

    public int defaultSpeed = 0;
    public int defaultJump = 0;
    public int addSpeed = 0;
    public int addJump = 0;
    public int dashSpeed = 0;

    public float rotationSpeed = 180f;

    public bool isDash = false;
    public bool isJumping = false;
    public bool isRotating = false;
    public bool isMouseDown = false;
    public bool isMouseDown2 = false;

    public bool isSpeedUp = false;

    private Rigidbody2D rigid;

    [SerializeField] private AudioClip audioDash;
    [SerializeField] private AudioClip audioJump;
    [SerializeField] private AudioClip audioDamaged;
    [SerializeField] private AudioClip audioFinish;
    [SerializeField] private AudioClip audioItem;

    [SerializeField] private AudioSource audioSource; // 플레이어는 본인이 가져야 하는 이유가 있음

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource.volume = SoundManager.Instance.GetSFXVolume();
        Reset();
    }

    public void Reset()
    {
        int characterNumber = PlayerData.Instance.characterNumber;

        var data = ResourceManager.Instance.GetFriendlyDataByLevel(characterNumber);
        defaultSpeed = data.speed;
        defaultJump = data.jump;

        currentSpeed = defaultSpeed;
        currentJump = defaultJump;
        addSpeed = data.addSpeed;
        addJump = data.addJump;
        dashSpeed = data.dashSpeed;

        rotationSpeed = 180f;
        isDash = false;
        isJumping = false;
        isRotating = false;
        isMouseDown = false;
        isMouseDown2 = false;
        rigid.velocity = Vector2.zero;
        rigid.SetRotation(0);
    }

    void Update()
    {
        rigid.velocity = new Vector2(currentSpeed, rigid.velocity.y);

        if (isDash && !isSpeedUp)
        {
            currentSpeed = dashSpeed;
            isSpeedUp = true; //
            isDash = false;
            Invoke("SpeedDown", 1f);
        }

        if (isJumping)
            rigid.rotation -= rotationSpeed * Time.deltaTime;

        isMouseDown2 = IsDashButtonDown();
        isMouseDown = IsJumpButtonDown();
        isRotating = IsRotate();

        if (isMouseDown2 && !isDash)
        {
            isDash = true;
            PlaySound("DASH");
        }

        if (isMouseDown && !isJumping && !isRotating)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, currentJump);
            isJumping = true;
            PlaySound("JUMP");
        }
    }

    private bool IsDashButtonDown()
    {
#if UNITY_ANDROID
        return Input.touchCount > 1;
#elif UNITY_STANDALONE_WIN
        return Input.GetButtonDown("Dash");
#endif
    }

    private bool IsJumpButtonDown()
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
            StageManager.Instance.DieText();
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
                currentJump = defaultJump + addJump;
                Invoke("JumpDown", 2f);
            }
            else if (itemObject is SpeedUpObject)
            {
                // 스피드 업
                currentSpeed = defaultSpeed + addSpeed;
                isSpeedUp = true;
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
        currentJump = defaultJump;
    }

    void SpeedDown()
    {
        currentSpeed = defaultSpeed;
        isSpeedUp = false;
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "DASH":
                audioSource.clip = audioDash;
                break;
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