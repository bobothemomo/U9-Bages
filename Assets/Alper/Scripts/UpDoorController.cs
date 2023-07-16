using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpController : MonoBehaviour
{
    public float acilmaHizi = 30f; // Kap�n�n a��lma h�z� (derece/saniye)
    public float hedefYukseklik = 5f; // Hedef y�kseklik

    private Vector3 baslangicPozisyon; // Kap�n�n ba�lang�� pozisyonu
    private bool kapilarAciliyor = false;

    private void Start()
    {
        // Ba�lang�� pozisyonunu kaydedin
        baslangicPozisyon = transform.position;
    }

    private void Update()
    {
        // Kap�lar a��l�yorsa pozisyonu g�ncelleyin
        if (kapilarAciliyor)
        {
            float yukseklikMiktari = acilmaHizi * Time.deltaTime;
            Vector3 hedefPozisyon = new Vector3(transform.position.x, baslangicPozisyon.y + hedefYukseklik, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, hedefPozisyon, yukseklikMiktari);

            // Hedef pozisyona ula��ld���nda kap�lar�n a��lmas�n� durdurun
            if (transform.position.y >= baslangicPozisyon.y + hedefYukseklik)
            {
                kapilarAciliyor = false;
            }
        }
    }

    public void Ac()
    {
        // Kap�lar�n a��lmas�n� ba�latmak i�in �a�r�lan bir metod
        kapilarAciliyor = true;
    }

    public void Sifirla()
    {
        // Kap� pozisyonunu ba�lang�� pozisyonuna s�f�rlamak i�in �a�r�lan bir metod
        transform.position = baslangicPozisyon;
        kapilarAciliyor = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("airBall")) // Topa �arp��ma
        {
            if (!kapilarAciliyor)
                kapilarAciliyor = true; // Kap�lar�n a��lma durumunu aktifle�tir
               
        }
    }
}
