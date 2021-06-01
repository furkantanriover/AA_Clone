using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircleController : MonoBehaviour
{
    [SerializeField]
    public GameObject smallCircle;
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("TagGameManager");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnSmallCircle();
        }
    }

    void SpawnSmallCircle()
    {
        Instantiate(smallCircle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().SetSmallCircleText();
    }
}
