using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScr : MonoBehaviour
{
    public float jumpForce = 5f; // Zýplama kuvveti

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            animator.SetTrigger("jump");

            
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);


        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

}
