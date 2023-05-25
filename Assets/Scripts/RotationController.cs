using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    GameObject cylinder;
    public float rotationSpeed = 5f;
    float moveX;
    public GameController gameController;

    void Awake()
    {
        cylinder = GameObject.Find("Silindir");
        gameController = GameController.instance;
    }
    private void Start()
    {
        gameController = GameController.instance;
    }

    void Update()
    {
        moveX = Input.GetAxis("Mouse X");
        Rotator();
    }

    void Rotator()
    {
        if (gameController.gameState != GameState.Playing)
        {
            return;
        }
        print(gameController.gameState);

        if (Input.GetMouseButton(0))
            cylinder.transform.Rotate(0f, -moveX * rotationSpeed, 0f);
    }
}
