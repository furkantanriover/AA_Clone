using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kucukCemberKod : MonoBehaviour
{

    Rigidbody2D fizik;
    public float hiz;
    bool hareketkontrol = false;
    GameObject oyunYoneticisi;


    // Start is called before the first frame update
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        oyunYoneticisi = GameObject.FindGameObjectWithTag("oyunYoneticisiTag");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hareketkontrol)
        {
            fizik.MovePosition(fizik.position + Vector2.up * hiz * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="donenCemberTag")
        {
            transform.SetParent(col.transform);
            hareketkontrol = true;
        }

        if(col.tag=="kucukCemberTag")
        {
            oyunYoneticisi.GetComponent<OyunYoneticisi>().OyunBitti();
        }
    }
}
