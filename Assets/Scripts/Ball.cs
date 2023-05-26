using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject splashPrefab;
    [Range(120, 500), SerializeField] float jumpForce = 400f;
    GameController gameController;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameController.instance;
    }

    void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * Time.deltaTime, rb.velocity.z);

        GameObject _splash = Instantiate(splashPrefab, transform.position - new Vector3(0, .21f, -0.2f), Quaternion.identity);
        _splash.transform.parent = other.transform;
        _splash.transform.rotation = Quaternion.Euler(-90, 0, 0);

        if (other.gameObject.tag == "Killer")
        {
            Debug.Log("Öldün");
            gameController.gameState = GameState.GameOver;
            gameController.screens[2].SetActive(true);
        }
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Kazandın tb");
            gameController.gameState = GameState.GameOver;
            gameController.screens[3].SetActive(true);
        }
    }
}
