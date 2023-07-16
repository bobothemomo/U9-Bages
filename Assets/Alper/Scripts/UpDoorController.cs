using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpController : MonoBehaviour
{
    public float acilmaHizi = 30f; // Kapýnýn açýlma hýzý (derece/saniye)
    public float hedefYukseklik = 5f; // Hedef yükseklik

    private Vector3 baslangicPozisyon; // Kapýnýn baþlangýç pozisyonu
    private bool kapilarAciliyor = false;

    private void Start()
    {
        // Baþlangýç pozisyonunu kaydedin
        baslangicPozisyon = transform.position;
    }

    private void Update()
    {
        // Kapýlar açýlýyorsa pozisyonu güncelleyin
        if (kapilarAciliyor)
        {
            float yukseklikMiktari = acilmaHizi * Time.deltaTime;
            Vector3 hedefPozisyon = new Vector3(transform.position.x, baslangicPozisyon.y + hedefYukseklik, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, hedefPozisyon, yukseklikMiktari);

            // Hedef pozisyona ulaþýldýðýnda kapýlarýn açýlmasýný durdurun
            if (transform.position.y >= baslangicPozisyon.y + hedefYukseklik)
            {
                kapilarAciliyor = false;
            }
        }
    }

    public void Ac()
    {
        // Kapýlarýn açýlmasýný baþlatmak için çaðrýlan bir metod
        kapilarAciliyor = true;
    }

    public void Sifirla()
    {
        // Kapý pozisyonunu baþlangýç pozisyonuna sýfýrlamak için çaðrýlan bir metod
        transform.position = baslangicPozisyon;
        kapilarAciliyor = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("airBall")) // Topa çarpýþma
        {
            if (!kapilarAciliyor)
                kapilarAciliyor = true; // Kapýlarýn açýlma durumunu aktifleþtir
               
        }
    }
}
