using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 6.0f, -4.0f);

    void LateUpdate()
    {
        if (player.activeInHierarchy)
        {
            transform.position = player.transform.position + offset;
        } 
    }
}