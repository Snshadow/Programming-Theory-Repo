using System.Collections;
using UnityEngine;

public class RandomizeMove : MonoBehaviour
{
    protected GameManager gameManager;

    protected GameObject target;
    protected Rigidbody spawnedRb;

    private float trigger = 0;

    public float directPower = 10.0f;

    public float maxPower = 400.0f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnedRb = gameObject.GetComponent<Rigidbody>();
        target = gameManager.player;
    }

    void Update()
    {
        trigger = Random.value;

        if (directPower < maxPower)
            directPower += Time.deltaTime * 10;
    }

    public void RunPattern(MovePattern pattern)
    {
        if ((trigger > 0.5f) && (gameManager.time > 10.0f))
            StartCoroutine(pattern.Operate());
    }
}

public abstract class MovePattern : RandomizeMove
{
    public virtual IEnumerator Operate() { yield return null; }
}

public class RandomDirection : MovePattern
{
    public override IEnumerator Operate()
    {

        float xDir = Random.Range(-0.2f, 0.2f);
        
        if (spawnedRb != null && Mathf.Abs(spawnedRb.velocity.x) < 10)
            spawnedRb.AddForce(new Vector3(xDir, 0, 0) * directPower * 100);
        
        yield return null;
    }
}

public class TowardPlayer : MovePattern
{
    public override IEnumerator Operate()
    {
        if (spawnedRb != null)
            spawnedRb.AddForce((target.transform.position - gameObject.transform.position).normalized * directPower);

        yield return null;
    }
}