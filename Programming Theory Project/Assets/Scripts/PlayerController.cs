using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameManager gameManager;

    private float xBound = 35.0f;

    private float control;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        Update_MousePosition();
        MovePlayer();
    }

    private void Update_MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        control = mousePos.x / 25 - 35.0f;
    }

    void MovePlayer()
    {
        if (gameManager.isGameActive)
        {
            if (control >= -xBound && control <= xBound)
            {
                transform.position = new Vector3(control, transform.position.y, transform.position.z);
            }
        }

    }
}