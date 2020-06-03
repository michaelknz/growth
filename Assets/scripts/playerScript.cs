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
        is_jump = !Check_Gnd();
        if (Input.GetKey(KeyCode.D) && (!is_jump))
        {
            dir += new Vector3(Mathf.Min(speed,max_speed-dir.x), 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && (!is_jump))
        {
            dir += new Vector3(Mathf.Max(-speed,-max_speed-dir.x), 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W) && (!is_jump))
        {
            rb.AddForce(new Vector2(0, jump_force));
            is_jump = true;
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
        Debug.Log(dir.x);
    }

    

    bool Check_Gnd()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        int layer = (1 << 8);
        //return Physics2D.OverlapCircle(transform.position-new Vector3(0.0f,0.65f,0f), 0.22f, layer);
        Debug.Log(Physics2D.OverlapBox(collider.bounds.center, collider.bounds.size, 0.0f, layer));
        return Physics2D.OverlapBox(collider.bounds.center, collider.bounds.size, 0.0f, layer);
    }
}
