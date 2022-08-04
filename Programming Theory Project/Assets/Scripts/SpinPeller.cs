using UnityEngine;

public class SpinPeller : MonoBehaviour
{
    public float angle = 1080.0f;
    void FixedUpdate()
    {
        transform.Rotate(0, 0, angle / 25);
    }
}
