using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool isOpen = false;
    public GameObject player;

    


    void Start()
    {
        player = GameObject.Find("Player");

    }


    public void OnCollisionEnter(Collision collision)
    {
        if (isOpen == true)
        {
            transform.Rotate(Vector3.up * -90);

        }

     
    }

    
}
