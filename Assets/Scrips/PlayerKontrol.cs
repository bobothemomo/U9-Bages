using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerKontrol : MonoBehaviour
{
    Animator anim;

    public float moveSpeed = 5f;
    public float glideForce;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool isDoubleJumping = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
         anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

        // Zıplama girişini kontrol et
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                Jump();
                isJumping = true;
                anim.SetTrigger("jump");

            }
            else if (!isDoubleJumping)
            {
                DoubleJump();
                isDoubleJumping = true;
            }
        }
        if (Input.GetKey(KeyCode.E) && isJumping)
        {
            glideForce += 0.2f; // Süzülme kuvvetini artırın veya azaltın
        }
        else
        {
            glideForce = 5f; // E tuşu basılı değilse süzülme kuvvetini sıfırlayın
        }
    }
    private void FixedUpdate()
    {
        // Süzülme kuvvetini uygula
        if (isJumping && rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.up * glideForce, ForceMode.Acceleration);
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
    }

    private void DoubleJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * 2f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isDoubleJumping = false;
        }
    }



































    /*
     private float speed;
     public int maxJumps = 2;
     private int jumpCount = 0;
     public float jumpForce = 5f;

     private bool facingRight = true;


     public float ziplamaGucu = 5f;

     private Rigidbody rb;
     private void Start()
     {
         anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody>();
     }

     private void Update()
     {
         jump(); 

         Move();

         atılma();

     }
     void atılma()
     {
         if (Input.GetKeyDown(KeyCode.W))
         {
             Debug.Log("w bastın");
             if (IsOnGround())
             {
                 if (facingRight)
                 {
                     rb.AddForce(new Vector2(speed, 0f), ForceMode.Impulse);
                 }
                 else
                 {
                     rb.AddForce(new Vector2(-speed, 0f), ForceMode.Impulse);
                 }
             }
         }
     }

     void jump()
     {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             //rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.VelocityChange);
             if (jumpCount < maxJumps)
             {
                 rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset vertical velocity

                 if (facingRight)
                 {
                     rb.AddForce(new Vector2(jumpForce, jumpForce), ForceMode.Impulse);
                 }
                 else
                 {
                     rb.AddForce(new Vector2(-jumpForce, jumpForce), ForceMode.Impulse);
                 }
             }
             anim.SetTrigger("jump");
             jumpCount++;
         }
     }
     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Ground"))
         {
             jumpCount = 0; // Reset jump count when colliding with the ground
         }

     }
     bool IsOnGround()
     {
         float raycastDistance = 0.1f;
         RaycastHit hit;
         if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
         {
             return true;
         }
         return false;
     }

     void Move()
     {
         float hrz = Input.GetAxis("Horizontal");  // Yatay hareket girişini al
         float vrt = Input.GetAxis("Vertical");  // Dikey hareket girişini al

         Vector3 hareket = new Vector3(hrz*speed, 0f, vrt*speed);  // Hareket vektörünü oluştur

         anim.SetFloat("speed", hareket.magnitude);

     }
    */
}


