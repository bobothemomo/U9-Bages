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
            Debug.Log("r bast�n");
            anim.SetTrigger("throwAir");
            StartCoroutine(WaitAirBall());

            IEnumerator WaitAirBall()
            {
                airBallActive = true;
                yield return new WaitForSeconds(1.5f);
                Debug.Log("2f bekledi");

                // Topun do�aca�� pozisyonu hesapla
                Vector3 firlatmaPozisyonu = transform.position + (transform.up * firlatmaMesafesi);

                // Topu do�ru pozisyonda olu�tur
                GameObject firlatilanTop = Instantiate(topPrefab, firlatmaPozisyonu, transform.rotation);
                // F�rlat�lan topa h�z ver
                Rigidbody topRigidbody = firlatilanTop.GetComponent<Rigidbody>();
                topRigidbody.velocity = transform.forward * firlatmaHizi;
                yield return new WaitForSeconds(3f);
                airBallActive = false;

            }

        }
    }


}
