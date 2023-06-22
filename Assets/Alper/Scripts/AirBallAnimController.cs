using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirBallAnimController : MonoBehaviour
{
    Animator anim;
    public GameObject topPrefab; // F�rlat�lacak topun prefab'i
    public float firlatmaMesafesi = 1f; // Topun karakterin transformundan ��k�� mesafesi
    public float firlatmaHizi = 10f; // Topun f�rlatma h�z�
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
            Debug.Log("r bast�n");
            anim.SetTrigger("throwAir");
            
            // Topun do�aca�� pozisyonu hesapla
            Vector3 firlatmaPozisyonu = transform.position + (transform.up * firlatmaMesafesi);

            // Topu do�ru pozisyonda olu�tur
            GameObject firlatilanTop = Instantiate(topPrefab, firlatmaPozisyonu, transform.rotation);

            // F�rlat�lan topa h�z ver
            Rigidbody topRigidbody = firlatilanTop.GetComponent<Rigidbody>();
            topRigidbody.velocity = transform.forward * firlatmaHizi;

        }
    }
   

}
