using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    Text spinningCircleText, one, two, three;
    [SerializeField]
    int smallCircleCount;

    GameObject spinningCircle;
    GameObject mainCircle;
    bool gameOverControl = true;

    void Start()
    {
        PlayerPrefs.SetInt("level",int.Parse(SceneManager.GetActiveScene().name));
        spinningCircle = GameObject.FindGameObjectWithTag("TagSpinningCircle");
        mainCircle = GameObject.FindGameObjectWithTag("TagMainCircle");
        spinningCircleText.text = SceneManager.GetActiveScene().name;

        if (smallCircleCount < 2)
        {
            one.text = smallCircleCount + "";
        }
        else if (smallCircleCount < 3)
        {
            one.text = smallCircleCount + "";
            two.text = (smallCircleCount - 1) + "";
        }
        else
        {
            one.text = smallCircleCount + "";
            two.text = (smallCircleCount - 1) + "";
            three.text = (smallCircleCount - 2) + "";
        }
    }

    IEnumerator LevelCompleted()
    {  
        spinningCircle.GetComponent<SpinningController>().enabled = false;
        mainCircle.GetComponent<MainCircleController>().enabled = false;
        
        if (gameOverControl)
        {
            animator.SetTrigger("NewLevel");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
        
    }

    public void SetSmallCircleText()
    {
        smallCircleCount--;
        if (smallCircleCount < 2)
        {
            one.text = smallCircleCount + "";
            two.text = "";
            three.text = "";
        }
        else if (smallCircleCount < 3)
        {
            one.text = smallCircleCount + "";
            two.text = (smallCircleCount - 1) + "";
            three.text = "";
        }
        else
        {
            Debug.Log("azaltma");
            one.text = smallCircleCount + "";
            two.text = (smallCircleCount - 1) + "";
            three.text = (smallCircleCount - 2) + "";
        }

        if (smallCircleCount == 0)
        {
            StartCoroutine(LevelCompleted());   
        }
    }

    public void GameOverMethod()
    {       
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        gameOverControl = false;
        spinningCircle.GetComponent<SpinningController>().enabled = false;
        mainCircle.GetComponent<MainCircleController>().enabled = false;  
        animator.SetTrigger("GameOver");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }

}
