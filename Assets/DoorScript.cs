using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpen = false;
    public Animator doorAnimator;

    public void TriggerAnimation()
    {
        if (!isOpen)
        {
            doorAnimator.SetTrigger("Open"); 
            isOpen = true;
        }
    }
}