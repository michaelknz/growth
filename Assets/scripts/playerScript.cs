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
    private bool is_double_jump;
    public float max_speed;
    private bool first_time;
    private Vector3 dir;
    private animations_for_player anim;
    public float sit_down_del;
    private bool s_flag;

    void Awake()
    {
        is_jump = false;
        is_double_jump = false;
        first_time = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        dir = new Vector3(0, 0, 0);
        anim = GetComponent<animations_for_player>();
        s_flag = false;
    }

    
    void Update()
    {
        is_jump = !Check_Gnd();
        if (!first_time)
        {
            anim.Set_Jump(is_jump);
        }
        if (Input.GetKey(KeyCode.D) && (!is_jump))
        {
            dir += new Vector3(Mathf.Min(speed,max_speed-dir.x), 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && (!is_jump))
        {
            dir += new Vector3(Mathf.Max(-speed,-max_speed-dir.x), 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W) && (!is_double_jump))
        {
            rb.AddForce(new Vector2(0, jump_force));
            if (is_jump)
            {
                is_double_jump = true;
            }
        }
        if (Input.GetKey(KeyCode.S) && !s_flag)
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size -= new Vector2(0.0f, sit_down_del);
            collider.offset -= new Vector2(0, sit_down_del / 2);
            s_flag = true;
        }
        if (!(is_jump))
        {
            is_double_jump = false;
        }

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
        if (is_jump == false)
        {
            first_time = false;
        }
        if (!Input.GetKey(KeyCode.S) && s_flag)
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size += new Vector2(0.0f, sit_down_del);
            collider.offset += new Vector2(0, sit_down_del / 2);
            s_flag = false;
        }
    }

    

    public bool Check_Gnd()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        int layer = (1 << 8);
        return Physics2D.OverlapBox(collider.bounds.center, collider.bounds.size, 0.0f, layer);
    }
}
