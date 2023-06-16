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

    [SerializeField]
    private float speed;
    public float ziplamaGucu = 5f;
 

    private bool isGround;
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
    }

    void jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.VelocityChange);
            anim.SetTrigger("jump");
        }
    }
    
    void Move()
    {
        float hrz = Input.GetAxis("Horizontal");  // Yatay hareket girişini al
        float vrt = Input.GetAxis("Vertical");  // Dikey hareket girişini al

        Vector3 hareket = new Vector3(hrz*speed, 0f, vrt*speed);  // Hareket vektörünü oluştur

        anim.SetFloat("speed", hareket.magnitude);

    }

      void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}


