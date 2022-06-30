using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SphereController : MonoBehaviour
{

    public TextMeshProUGUI coordText;

    Rigidbody rb;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        coordText.text = transform.position.ToString();
        if (i < 400)
        {
            rb.AddForce(0, 10, 10);
            ++i;
        }
        else
        {
            rb.AddForce(0, 1, -0.1f);
        }
    }
}
