using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public ParticleSystem explodeEffect;

    [SerializeField] protected float speed = 40.0f;

    private float zDestroy = -60.0f;
    
    private GameManager gameManager;
    private RandomizeMove randomizeMove;

    private ParticleSystem spawnedEffect;
    private Rigidbody objectRb;

    [SerializeField] private MovePattern pattern;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        randomizeMove = gameObject.AddComponent<RandomizeMove>();

        spawnedEffect = Instantiate(explodeEffect, transform.position + Vector3.forward * -2, explodeEffect.transform.rotation, transform);

        pattern = Random.value < 0.5 ? gameObject.AddComponent<RandomDirection>() : gameObject.AddComponent<TowardPlayer>();
    }

    void Update()
    {
        Move();
        randomizeMove.RunPattern(pattern);

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
            spawnedEffect.Play();
            spawnedEffect.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}
