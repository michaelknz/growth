using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations_for_player : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("right");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("left");
        }
    }
    

}

