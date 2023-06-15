using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScr : MonoBehaviour
{
    PlayerKontrol playerControl;
    private Animator animator;

    float moveValue;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerControl = GetComponent<PlayerKontrol>();
    }

    void Update()
    {
        SetAnim();
    }

    void SetAnim()
    {
        moveValue = playerControl.movement.magnitude;
        

        animator.SetFloat("Speed", moveValue);
        animator.SetFloat("Yatay", playerControl.movement.y);
        animator.SetFloat("Dikey", playerControl.movement.x);
    }

}
