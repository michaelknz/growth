using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations_for_player : MonoBehaviour
{
    Animator anim;
    private bool is_jump;
    void Start()
    {
        anim = GetComponent<Animator>();
        is_jump = false;
    }
    void Update()
    { 
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
        if (Input.GetKeyDown(KeyCode.D) && !is_jump)
        {
            anim.SetTrigger("right");
        }
        else if (Input.GetKeyDown(KeyCode.A) && !is_jump)
        {
            anim.SetTrigger("left");
        }
    }

    public void Set_Jump(bool val)
    {
        is_jump = val;
    }
}

