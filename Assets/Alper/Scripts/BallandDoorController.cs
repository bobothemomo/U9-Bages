using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallandDoorController : MonoBehaviour
{

    public float yokOlmaSuresi = 3f; // Topun yok olma süresi
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("door")) // Kapý ile çarpýþma
        {
            Destroy(collision.gameObject); // Kapýyý yok et
        }
        /*else // Diðer nesnelerle çarpýþma
        {
           Debug.Log("top yok oldu.");
           Destroy(gameObject); // Topu yok et
         }*/
    }
    void Start()
    {
        // Topun belirli bir süre sonra yok olmasý için süreleyiciyi baþlat
        Invoke("YokOl", yokOlmaSuresi);
    }


    private void YokOl()
    {
        Destroy(gameObject); // Topu yok et
    }   
}
