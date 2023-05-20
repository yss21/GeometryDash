using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    float time = 0;

    [SerializeField] private float titleAnimDelta = 2.0f;

    void Update()
    {
        transform.localScale = Vector3.one + Vector3.one * Mathf.Abs(Mathf.Sin(time) / titleAnimDelta);
        time += Time.deltaTime;
    }
}