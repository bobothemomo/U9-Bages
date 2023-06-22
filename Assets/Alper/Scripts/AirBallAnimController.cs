using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirBallAnimController : MonoBehaviour
{
    Animator anim;
    public GameObject topPrefab; // Fýrlatýlacak topun prefab'i
    public float firlatmaMesafesi = 1f; // Topun karakterin transformundan çýkýþ mesafesi
    public float firlatmaHizi = 10f; // Topun fýrlatma hýzý
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
            
            // Topun doðacaðý pozisyonu hesapla
            Vector3 firlatmaPozisyonu = transform.position + (transform.up * firlatmaMesafesi);

            // Topu doðru pozisyonda oluþtur
            GameObject firlatilanTop = Instantiate(topPrefab, firlatmaPozisyonu, transform.rotation);

            // Fýrlatýlan topa hýz ver
            Rigidbody topRigidbody = firlatilanTop.GetComponent<Rigidbody>();
            topRigidbody.velocity = transform.forward * firlatmaHizi;

        }
    }
   

}
