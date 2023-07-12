using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorController : MonoBehaviour
{
    public float acilmaHizi = 30f; // Kapýnýn açýlma hýzý (derece/saniye)
    public float hedefRotasyon = 360f; // Hedef rotasyon açýsý

    private Quaternion baslangicRotasyonu; // Kapýnýn baþlangýç rotasyonu
    private bool kapilarAciliyor = false; // Kapýlarýn açýlma durumu

    private void Start()
    {
        baslangicRotasyonu = transform.rotation; // Baþlangýç rotasyonunu kaydet
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("airBall")) // Topa çarpýþma
        {
            if (!kapilarAciliyor)
            {
                kapilarAciliyor = true; // Kapýlarýn açýlma durumunu aktifleþtir
                baslangicRotasyonu = transform.rotation; // Baþlangýç rotasyonunu kaydet
            }
        }
    }

    private void Update()
    {
        if (kapilarAciliyor)
        {
            // Kapýnýn yavaþ yavaþ açýlmasý için rotasyonu güncelle
            Quaternion hedefRotasyonQuat = Quaternion.Euler(0f, hedefRotasyon, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, hedefRotasyonQuat, acilmaHizi * Time.deltaTime);

            // Hedef rotasyona ulaþýldýðýnda kapýlarýn açýlma durumunu devre dýþý býrak
            if (Quaternion.Angle(transform.rotation, hedefRotasyonQuat) < 0.01f)
            {
                kapilarAciliyor = false;
            }
        }
    }

    public void ResetKapilar()
    {
        transform.rotation = baslangicRotasyonu; // Kapýlarý baþlangýç rotasyonuna döndür
    }
}
