using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameManager gameManager;

    private Vector3 mousePos;
    private float xBound = 35.0f;
    [SerializeField] private bool jumpState = false;
    private float time;
    private float soarTime;
    private float upTime;

    private Vector3 defaultPos;
    private Vector3 jumpHeight = Vector3.up;

    private float mouseControl;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        defaultPos = transform.position;
    }

    void Update()
    {
        time = Time.time;
        Update_MousePosition();
        MovePlayer();
        StartCoroutine(PlayerJump());
    }

    void Update_MousePosition()
    {
        mousePos = Input.mousePosition;
        mouseControl = mousePos.x / 25 - 35.0f;
    }

    void MovePlayer()
    {
        if (gameManager.isGameActive)
        {
            if (mouseControl >= -xBound && mouseControl <= xBound)
            {
                transform.position = new Vector3(mouseControl, transform.position.y, transform.position.z);
            }
        }

    }

    //현재는 position만 변경
    IEnumerator PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jumpState)
            {
                soarTime = time;
                upTime = 0.6f;
                jumpState = !jumpState;
                while (upTime > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, defaultPos.y + jumpHeight.y, transform.position.z), upTime);
                    upTime -= Time.deltaTime;
                    yield return null;
                }
                transform.position = new Vector3(transform.position.x, defaultPos.y, transform.position.z) + jumpHeight;
            }
        }
        if (time - soarTime >= 2 && jumpState)
        {
            upTime = 0.4f;
            while (upTime < 1) 
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, defaultPos.y, transform.position.z), upTime);
                upTime += Time.deltaTime;
                yield return null;
            }
            transform.position = new Vector3(transform.position.x, defaultPos.y, transform.position.z);
            jumpState = !jumpState;
        }

    }

}