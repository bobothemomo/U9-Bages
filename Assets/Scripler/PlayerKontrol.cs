using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKontrol : MonoBehaviour
{
    [SerializeField] float speed = 5f, jumpForce;

    [HideInInspector] public Vector2 movement;

    Rigidbody playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector3(movement.x * speed, playerRB.velocity.y, movement.y * speed);
        
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
} 

