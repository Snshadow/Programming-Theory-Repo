using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed = 40.0f;

    private float zDestroy = -60.0f;
    private GameManager gameManager;

    protected Rigidbody objectRb; 

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        Move();

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Move()
    {
        objectRb.AddForce(0, 0, -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameManager.isGameActive)
        {
            gameManager.GameOver();
        } 
    }

}
