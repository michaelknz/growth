using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private float speed;
    private float jump_force;
    private Rigidbody2D rb;

    void Start()
    {
        speed = 5.0f;
        jump_force = 500.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(speed * Time.deltaTime * (-1), 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jump_force));
        }
    }
}
