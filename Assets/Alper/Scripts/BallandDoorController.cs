using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallandDoorController : MonoBehaviour
{

    public float yokOlmaSuresi = 3f; // Topun yok olma s�resi
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("door")) // Kap� ile �arp��ma
        {
            Destroy(collision.gameObject); // Kap�y� yok et
        }
        /*else // Di�er nesnelerle �arp��ma
        {
           Debug.Log("top yok oldu.");
           Destroy(gameObject); // Topu yok et
         }*/
    }
    void Start()
    {
        // Topun belirli bir s�re sonra yok olmas� i�in s�releyiciyi ba�lat
        Invoke("YokOl", yokOlmaSuresi);
    }


    private void YokOl()
    {
        Destroy(gameObject); // Topu yok et
    }   
}
