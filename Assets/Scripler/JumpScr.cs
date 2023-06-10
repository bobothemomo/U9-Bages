using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScr : MonoBehaviour
{
    PlayerKontrol playerControl;
    private Animator animator;

    float moveValue;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerControl = GetComponent<PlayerKontrol>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    animator.SetTrigger("jump");


        //    rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);


        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    animator.SetBool("jump", true);
        //}
        //else
        //{
        //    animator.SetBool("jump", false);
        //}
        SetAnim();
    }

    void SetAnim()
    {
        moveValue = playerControl.movement.magnitude;

        animator.SetFloat("Speed", moveValue);
        animator.SetFloat("Yatay", playerControl.movement.y);
        animator.SetFloat("Dikey", playerControl.movement.x);
    }

}
