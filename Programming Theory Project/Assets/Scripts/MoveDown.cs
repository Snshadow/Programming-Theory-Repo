using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] protected float speed = 40.0f;

    private float zDestroy = -60.0f;
    
    protected GameManager gameManager;
    protected SpawnManager spawnManager;

    protected Rigidbody objectRb;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        Move();

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        objectRb.AddForce(0, 0, -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameManager.isGameActive)
        {
            gameManager.GameOver();
        }
        else if (collision.gameObject.CompareTag("Shootable"))
        {
            spawnManager.carriedEffect.Play();
            Destroy(gameObject);
        }
    }

}
