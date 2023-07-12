using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorController : MonoBehaviour
{
    public float acilmaHizi = 30f; // Kap�n�n a��lma h�z� (derece/saniye)
    public float hedefRotasyon = 360f; // Hedef rotasyon a��s�

    private Quaternion baslangicRotasyonu; // Kap�n�n ba�lang�� rotasyonu
    private bool kapilarAciliyor = false; // Kap�lar�n a��lma durumu

    private void Start()
    {
        baslangicRotasyonu = transform.rotation; // Ba�lang�� rotasyonunu kaydet
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("airBall")) // Topa �arp��ma
        {
            if (!kapilarAciliyor)
            {
                kapilarAciliyor = true; // Kap�lar�n a��lma durumunu aktifle�tir
                baslangicRotasyonu = transform.rotation; // Ba�lang�� rotasyonunu kaydet
            }
        }
    }

    private void Update()
    {
        if (kapilarAciliyor)
        {
            // Kap�n�n yava� yava� a��lmas� i�in rotasyonu g�ncelle
            Quaternion hedefRotasyonQuat = Quaternion.Euler(0f, hedefRotasyon, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, hedefRotasyonQuat, acilmaHizi * Time.deltaTime);

            // Hedef rotasyona ula��ld���nda kap�lar�n a��lma durumunu devre d��� b�rak
            if (Quaternion.Angle(transform.rotation, hedefRotasyonQuat) < 0.01f)
            {
                kapilarAciliyor = false;
            }
        }
    }

    public void ResetKapilar()
    {
        transform.rotation = baslangicRotasyonu; // Kap�lar� ba�lang�� rotasyonuna d�nd�r
    }
}
