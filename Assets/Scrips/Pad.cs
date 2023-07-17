using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public int padId;
    int objectsOnPad = 0;

    
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pickupable>() != null) 
        {
            objectsOnPad++;


            if (other.gameObject.GetComponent<Pickupable>().ReturnBoxId() == padId) 
            {

                ColorPadManager.instance.IncreaseCorrectPlacements(); 

            }

            ColorPadManager.instance.IncreasePlacement(); 
        }
    }

   
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Pickupable>() != null) 
        {
            objectsOnPad--; 
            ColorPadManager.instance.DecreasePlacement();


            if (other.gameObject.GetComponent<Pickupable>().ReturnBoxId() == padId) 
            {

                ColorPadManager.instance.DecreaseCorrectPlacements(); 
            }
        }

    }
}