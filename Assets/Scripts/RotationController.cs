using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    GameObject cylinder;
    public float rotationSpeed = 5f;
    float moveX;

    void Awake()
    {
        cylinder = GameObject.Find("Silindir");
    }

    void Update()
    {
        moveX = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {
            cylinder.transform.Rotate(0f, -moveX * rotationSpeed, 0f);
        }
    }
}
