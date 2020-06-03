using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class playerScript : MonoBehaviour
{
    public float speed;
    public float jump_force;
    private Rigidbody2D rb;
    public float speed_del;
    private bool is_jump;
    public float max_speed;
    private Vector3 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        dir = new Vector3(0, 0, 0);
        is_jump = false;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && (!is_jump))
        {
            dir += new Vector3(Mathf.Min(speed,max_speed-rb.velocity.x), 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && (!is_jump))
        {
            dir += new Vector3(Mathf.Max(-speed,-max_speed-rb.velocity.x), 0, 0);
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

        Debug.Log(is_jump);

        transform.position += dir * Time.deltaTime;
        if (!is_jump)
        {
            if (dir.x < 0)
            {
                dir -= new Vector3(Mathf.Max(-speed_del, dir.x), 0, 0);
            }
            else
            {
                dir -= new Vector3(Mathf.Min(speed_del, dir.x), 0, 0);
            }
        }
    }

    

    bool Check_Gnd()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        int layer = (1 << 8);
        Ray2D ray = new Ray2D();
        ray.origin = transform.position;
        //ray.direction = Vector2.up;
        Debug.DrawRay(ray.origin, new Vector2(0,0.86f), Color.red, 100.0f);
        return Physics2D.OverlapCircle(transform.position-new Vector3(0.0f,0.65f,0f), 0.22f, layer);
    }
}
