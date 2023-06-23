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

    bool airBallActive = false;
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
        if (Input.GetKeyDown(KeyCode.R) && airBallActive == false)
        {
            Debug.Log("r bastýn");
            anim.SetTrigger("throwAir");
            StartCoroutine(WaitAirBall());

            IEnumerator WaitAirBall()
            {
                airBallActive = true;
                yield return new WaitForSeconds(1.5f);
                Debug.Log("2f bekledi");

                // Topun doðacaðý pozisyonu hesapla
                Vector3 firlatmaPozisyonu = transform.position + (transform.up * firlatmaMesafesi);

                // Topu doðru pozisyonda oluþtur
                GameObject firlatilanTop = Instantiate(topPrefab, firlatmaPozisyonu, transform.rotation);
                // Fýrlatýlan topa hýz ver
                Rigidbody topRigidbody = firlatilanTop.GetComponent<Rigidbody>();
                topRigidbody.velocity = transform.forward * firlatmaHizi;
                yield return new WaitForSeconds(3f);
                airBallActive = false;

            }

        }
    }


}
