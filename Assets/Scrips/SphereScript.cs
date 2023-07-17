using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        DoorScript door = collision.gameObject.GetComponent<DoorScript>();
        if (door != null)
        {
            door.TriggerAnimation();
        }
    }
}