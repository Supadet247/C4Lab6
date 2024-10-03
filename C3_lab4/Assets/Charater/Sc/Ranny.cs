using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenyMovement : MonoBehaviour
{
    Animator anim;
    CharacterController controller;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        anim.SetBool("isDef", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("isDancing", false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isDef", true);
            anim.SetBool("isWalking", true);
            anim.SetBool("isDancing", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isDancing", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isDef", true);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            anim.SetBool("isDef", false);
            anim.SetBool("isDancing", true);
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isDef", true);
            anim.SetBool("isDancing", true);
            anim.SetBool("isWalking", false);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("isDef", true);
            anim.SetBool("isDancing", false);
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.G))
        {
            anim.SetBool("isDef", false);
            anim.SetBool("isDancing", false);
            anim.SetBool("isWalking", true);
        }
    } 
}
