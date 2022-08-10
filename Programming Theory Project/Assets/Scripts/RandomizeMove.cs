using System.Collections;
using UnityEngine;

public class RandomizeMove : MonoBehaviour
{
    protected GameManager gameManager;

    protected GameObject target;
    protected Rigidbody spawnedRb;

    private float trigger = 0;

    private float directPower = 10.0f;

    private float maxPower = 400.0f;

    public float DirectPower { get { return directPower; } protected set { directPower = value; } } // ENCAPSULATION
    public float MaxPower { get { return maxPower; } protected set { maxPower = value; } } // ENCAPSULATION

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnedRb = gameObject.GetComponent<Rigidbody>();
        target = gameManager.player;
    }

    void Update()
    {
        trigger = Random.value;

        if (DirectPower < MaxPower)
            DirectPower += Time.deltaTime * 10;
    }

    public void RunPattern(MovePattern pattern)
    {
        if ((trigger > 0.7f) && (gameManager.time > 10.0f))
            StartCoroutine(pattern.Operate());
    }
}

public abstract class MovePattern : RandomizeMove // INHERITANCE
{
    public virtual IEnumerator Operate() { yield return null; }
}

public class RandomDirection : MovePattern // INHERITANCE
{
    public override IEnumerator Operate() // POLYMORPHISM
    {

        float xDir = Random.Range(-0.2f, 0.2f);
        
        if (spawnedRb != null && Mathf.Abs(spawnedRb.velocity.x) < 10)
            spawnedRb.AddForce(new Vector3(xDir, 0, 0) * DirectPower * 100);
        
        yield return null;
    }
}

public class TowardPlayer : MovePattern // INHERITANCE
{
    public override IEnumerator Operate() // POLYMORPHISM
    {
        if (spawnedRb != null)
            spawnedRb.AddForce((target.transform.position - gameObject.transform.position).normalized * DirectPower);

        yield return null;
    }
}