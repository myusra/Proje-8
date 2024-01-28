using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    private Rigidbody rb;
    public float Hiz = 1.8f;
    public Text zaman, can, durum;
    float zamanSayaci = 500;
    float canSayaci = 100;
    bool oyunDevam = true;
    bool oyunTamam = false;
    public Button Buton;

    private void Update()
    {
        if(oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if(!oyunTamam)
        {
            durum.text = "Oyun'u tamamlayamadýnýz :(";
            Buton.gameObject.SetActive(true);
        }
        if (zamanSayaci<0)
        {
            oyunDevam = false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void FixedUpdate()
    {
        if(oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-yatay, 0, -dikey);
            rb.AddForce(kuvvet * Hiz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        string objIsmi = other.gameObject.name;
        if (objIsmi.Equals("Bitiþ"))
        {
            oyunTamam = true;
            durum.text = "Oyun tamamlandý. Tebrikler :)";
            Buton.gameObject.SetActive(true);
        }
        else if (!objIsmi.Equals("Baþlangýç") && !objIsmi.Equals("Yer"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)
            {
                oyunDevam = false;

            }
        }
        
    }


}
