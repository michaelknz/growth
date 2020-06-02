using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed;
    public float jump_force;
    private Rigidbody2D rb;
    public float speed_del;
    private bool is_jump;
    public float max_speed;
    public float radius_del;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.velocity = new Vector2(0,0);
        is_jump = false;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && (!is_jump))
        {
            rb.velocity += new Vector2(Mathf.Min(speed,max_speed-rb.velocity.x), 0);
        }
        if (Input.GetKey(KeyCode.A) && (!is_jump))
        {
            rb.velocity += new Vector2(Mathf.Max(-speed,-max_speed-rb.velocity.x), 0);
        }
        if (Input.GetKeyDown(KeyCode.W) && (!is_jump))
        {
            rb.AddForce(new Vector2(0, jump_force));
            is_jump = true;
        }
        if (Check_Gnd())
        {
            is_jump = false;
        }
    }

    

    bool Check_Gnd()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        int layer = (1 << 8);
        return Physics2D.OverlapCircle(transform.position-new Vector3(0.0f,1.21f,0f), 0.45f, layer);
    }
}
