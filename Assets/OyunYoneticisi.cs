using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject anaCember;
    public Animator animator;
    public Text donenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kacTaneKucukCemberOlsun;
    bool kontrol;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        int gelenDeger = PlayerPrefs.GetInt("kayit");
        donenCember = GameObject.FindGameObjectWithTag("donenCemberTag");
        anaCember = GameObject.FindGameObjectWithTag("anaCemberTag");
        donenCemberLevel.text = SceneManager.GetActiveScene().name;

        if(kacTaneKucukCemberOlsun<2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
        }
        else if(kacTaneKucukCemberOlsun<3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
    }

    public void kucukCemberlerdeTextGosterme()
    {
        kacTaneKucukCemberOlsun--;

        if (kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
        
        if(kacTaneKucukCemberOlsun==0)
        {
            StartCoroutine(yeniLevel());
        }
    }

    IEnumerator yeniLevel()
    {
        donenCember.GetComponent<dondurme>().enabled = false;
        anaCember.GetComponent<AnaCember>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(2);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
    }

    public void OyunBitti()
    {
        StartCoroutine(CagrilanMetot());
    }

    IEnumerator CagrilanMetot()
    {
        donenCember.GetComponent<dondurme>().enabled = false;
        anaCember.GetComponent<AnaCember>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("AnaMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
