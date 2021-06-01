using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCircleController : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D physics;
    bool motionController;
    GameObject gameManager;

    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("TagGameManager");
    }

    void FixedUpdate()
    {
        if (!motionController)
        {
            physics.MovePosition(physics.position + Vector2.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "TagSpinningCircle")
        {
            transform.SetParent(col.transform);
            motionController = true;
        }

        if(col.tag == "TagSmallCircle")
        {
            gameManager.GetComponent<GameManager>().GameOverMethod();
        }
    }
}
