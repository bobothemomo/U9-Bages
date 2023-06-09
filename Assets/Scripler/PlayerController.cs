using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterYurume : MonoBehaviour
{
    public float hiz = 5f; // Karakterin yürüme hýzý

    private Rigidbody karakterRigidbody;

    private void Start()
    {
        karakterRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal"); // sað-sol hareket
        float dikey = Input.GetAxis("Vertical"); // ileri-geri hareket

        Vector3 hareket = new Vector3(yatay, 0f, dikey);

        karakterRigidbody.velocity = hareket * hiz; // Karakterin hýzý
    }
}
