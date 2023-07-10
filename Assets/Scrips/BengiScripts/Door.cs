using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject warningPart;
    [SerializeField] TextMeshProUGUI warningText;
    public bool isOpen = false;

    [SerializeField] float speed;


    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen && other.gameObject.CompareTag("Player"))
        {
            warningPart.SetActive(true);
            warningText.text = "Kapý kilitli!";
        }
        else if (isOpen && other.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(DoorOpening());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!isOpen && other.gameObject.CompareTag("Player"))
        {
            
        }
    }

    IEnumerator DoorOpening()
    {
        while(transform.localEulerAngles.y >= 180f)
        {
            transform.Rotate(Vector3.up * speed);

            yield return null;
        }

    }

    
}
