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

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float yatayHareket = Input.GetAxis("Horizontal");  // Yatay hareket girişini al
        float dikeyHareket = Input.GetAxis("Vertical");  // Dikey hareket girişini al

        Vector3 hareket = new Vector3(yatayHareket*speed, 0f, dikeyHareket*speed);  // Hareket vektörünü oluştur

        //if (hareket.magnitude > 0f)  // Eğer karakter hareket ediyorsa
        //{
        //    Quaternion yeniYon = Quaternion.LookRotation(hareket);  // Hareket yönünü belirle
        //    transform.rotation = Quaternion.Slerp(transform.rotation, yeniYon, 0.15f);  // Yavaşça dön

        //    gameObject.transform.Translate(yatayHareket*Time.deltaTime,0,dikeyHareket*Time.deltaTime);
        //}

        anim.SetFloat("speed", hareket.magnitude);

    }
}


