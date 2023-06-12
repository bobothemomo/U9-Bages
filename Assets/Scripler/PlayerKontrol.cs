using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKontrol : MonoBehaviour
{
    public float hiz = 5f;  

    private Animator animator;  

    private void Start()
    {
        animator = GetComponent<Animator>();  
    }

    private void Update()
    {
        float yatayHareket = Input.GetAxis("Horizontal"); 
        float dikeyHareket = Input.GetAxis("Vertical");  

        Vector3 hareket = new Vector3(yatayHareket, 0f, dikeyHareket);  

        if (hareket.magnitude > 0f) 
        {
            Quaternion yeniYon = Quaternion.LookRotation(hareket);  
            transform.rotation = Quaternion.Slerp(transform.rotation, yeniYon, 0.15f);  

            transform.Translate(hareket * hiz * Time.deltaTime, Space.World);  
        }

        animator.SetFloat("Hiz", hareket.magnitude);  
    }
}




