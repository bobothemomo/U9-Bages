using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScr : MonoBehaviour
{
    PlayerKontrol playerControl;
    private Animator animator;
    private bool isJumping = false; // deðiþken

    public float jumpForce = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerControl = GetComponent<PlayerKontrol>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            
            Jump();
        }

        SetAnim();
    }

    void SetAnim()
    {
        float moveValue = playerControl.movement.magnitude;
        animator.SetFloat("Speed", moveValue);
        animator.SetFloat("Yatay", playerControl.movement.y);
        animator.SetFloat("Dikey", playerControl.movement.x);
    }

    void Jump()
    {
        

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        isJumping = true;
        animator.SetBool("IsJumping", true); // Zýplama animasyonunu etkinleþti
    }

    void OnCollisionEnter(Collision collision)
    {
        // Yere temas ettiðinde durum sýfýrlanrý

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false); // Zýplama animasyonunu devre dýþý
        }
    }
}

