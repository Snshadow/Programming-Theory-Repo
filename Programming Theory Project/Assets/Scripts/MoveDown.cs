using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 40.0f;

    private float zDestroy = -60.0f;
    private Rigidbody objectRb; 
    private GameManager gameManager;
    private ParticleSystem thrustFlame;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        thrustFlame = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        objectRb.AddForce(0, 0, -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameManager.isGameActive)
        {
            gameManager.GameOver();
        } 
    }
}
