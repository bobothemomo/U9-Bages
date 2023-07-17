using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    Rigidbody rb;
    public int boxId;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    /// <param name="holder"></param>
    public void SetPickedUpState(Transform holder)
    {
        rb.useGravity = false; 
        rb.isKinematic = true;
        transform.parent = holder; 
    }

    
    public void SetDroppedState()
    {
        rb.useGravity = true;
        transform.parent = null;
        rb.isKinematic = false;
    }

    
    public int ReturnBoxId()
    {
        return boxId;
    }
}