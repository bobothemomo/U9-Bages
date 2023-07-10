using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mesale : MonoBehaviour
{
    public Door door;

    [SerializeField] GameObject warningPart;
    [SerializeField] TextMeshProUGUI warningText;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.isOpen = true;
        }       
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            warningText.text = "Kapý açýldý";
            
            
        }
    }
}
