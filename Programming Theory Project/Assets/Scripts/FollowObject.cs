using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private Vector3 offset = new Vector3(0, 6.0f, -4.0f);

    void LateUpdate()
    {
        if (target.activeInHierarchy)
        {
            transform.position = target.transform.position + offset;
        } 
    }
}