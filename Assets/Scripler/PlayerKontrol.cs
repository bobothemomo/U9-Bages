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
        //float Yatay = 0f;
        //float Dikey = 0f;

        //if (Input.GetKey(KeyCode.W))
        //    Dikey = 1f;
        //else if (Input.GetKey(KeyCode.S))
        //    Dikey = -1f;

        //if (Input.GetKey(KeyCode.A))
        //    Yatay = -1f;
        //else if (Input.GetKey(KeyCode.D))
        //    Yatay = 1f;

        //Vector3 movement = new Vector3(Yatay, 0f, Dikey) * speed * Time.deltaTime;
        //transform.Translate(movement);
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector3(movement.x * speed, playerRB.velocity.y, movement.y * speed);
        Debug.Log(playerRB.velocity.y);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
} 

