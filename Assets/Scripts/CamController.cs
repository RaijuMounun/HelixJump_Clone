using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform ball;
    Vector3 offset;
    [Range(0, 1)] public float smoothSpeed = 0.5f;

    void Awake()
    {
        offset = transform.position - ball.position;
    }

    private void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, ball.position + offset, smoothSpeed);
        transform.position = newPos;
    }
}
