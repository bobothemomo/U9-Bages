using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{

    public Transform holdPosition;

    
    void Start()
    {

    }

    
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50.0f, Color.red);
        CheckForPickup();
    }

    
    private void CheckForPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20.0f)) 
        {
            if (Input.GetKey(KeyCode.Mouse0)) 
            {
                if (hit.transform.GetComponent<Pickupable>()) 
                {
                    hit.transform.GetComponent<Pickupable>().SetPickedUpState(transform); 

                }
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (hit.transform.GetComponent<Pickupable>())
                {
                    hit.transform.GetComponent<Pickupable>().SetDroppedState();

                }
            }

        }
    }
}
