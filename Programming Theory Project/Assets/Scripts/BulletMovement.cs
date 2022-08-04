using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 400.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = 60 * speed * Time.deltaTime * Vector3.forward;

        if (transform.position.z > 60)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
