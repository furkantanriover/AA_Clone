using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaCember : MonoBehaviour
{
    public GameObject kucukCember;
    GameObject OyunYonetici;

    // Start is called before the first frame update
    void Start()
    {
        OyunYonetici = GameObject.FindGameObjectWithTag("oyunYoneticisiTag");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            kucukCemberOlustur();
        }
    }
    void kucukCemberOlustur()
    {
        Instantiate(kucukCember, transform.position, transform.rotation);
        OyunYonetici.GetComponent<OyunYoneticisi>().kucukCemberlerdeTextGosterme();
    }
}
