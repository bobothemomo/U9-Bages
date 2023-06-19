using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBallController : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    private void Update()
    {
        AirBall();

    }

    void AirBall()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("r bastýn");
            anim.SetTrigger("throwAir");
        }
    }
}
