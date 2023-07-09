using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesale : MonoBehaviour
{
    public Door door;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.isOpen = true;
        }       
    }
}
